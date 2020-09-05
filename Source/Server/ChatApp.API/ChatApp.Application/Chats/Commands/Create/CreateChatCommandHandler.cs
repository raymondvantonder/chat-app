using ChatApp.Application.Interfaces;
using ChatApp.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp.Application.Chats.Commands.Create
{
    public class CreateChatCommandHandler : IRequestHandler<CreateChatCommand, long>
    {
        private readonly ILogger<CreateChatCommand> _logger;
        private readonly IChatAppDbContext _context;

        public CreateChatCommandHandler(ILogger<CreateChatCommand> logger, IChatAppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<long> Handle(CreateChatCommand request, CancellationToken cancellationToken)
        {
            ChatEntity chat = new ChatEntity() { Name = request.Name, CreatorId = request.CreatorId };

            foreach (long userId in request.Users)
            {
                chat.ChatParticipants.Add(new ChatParticipantEntity { User = await _context.Users.FindAsync(userId) });
            }

            if (!string.IsNullOrEmpty(request.Message))
            {
                chat.Messages.Add(new MessageEntity
                {
                    Message = request.Message,
                    SenderId = request.CreatorId
                });
            }

            await _context.Chats.AddAsync(chat);

            await _context.SaveChangesAsync(cancellationToken);

            return chat.Id;
        }
    }
}
