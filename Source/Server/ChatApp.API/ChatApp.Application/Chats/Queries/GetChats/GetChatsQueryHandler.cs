using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChatApp.Application.Chats.Queries.GetAll;
using ChatApp.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp.Application.Chats.Queries.GetChats
{
    public class GetChatsQueryHandler : IRequestHandler<GetChatsQuery, IEnumerable<ChatVm>>
    {
        private readonly ILogger<GetChatsQueryHandler> _logger;
        private readonly IChatAppDbContext _context;
        private readonly IMapper _mapper;

        public GetChatsQueryHandler(ILogger<GetChatsQueryHandler> logger, IMapper mapper, IChatAppDbContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<ChatVm>> Handle(GetChatsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Retreiving chats now..");

                return await _context.Chats
                    .Include(x => x.Messages)
                    .Include(x => x.ChatParticipants)
                    .ThenInclude(x => x.User)
                    .Include(x => x.Creator)
                    .Where(x => x.ChatParticipants.Any(x => x.UserId == request.UserId)).ProjectTo<ChatVm>(_mapper.ConfigurationProvider).ToListAsync();
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
