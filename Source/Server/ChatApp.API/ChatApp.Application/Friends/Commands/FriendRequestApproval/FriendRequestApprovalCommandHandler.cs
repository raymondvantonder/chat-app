using AutoMapper;
using ChatApp.Application.Common.Exceptions;
using ChatApp.Application.Interfaces;
using ChatApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp.Application.Friends.Commands.FriendRequestApproval
{
    public class FriendRequestApprovalCommandHandler : IRequestHandler<FriendRequestApprovalCommand>
    {
        private readonly ILogger<FriendRequestApprovalCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IChatAppDbContext _context;

        public FriendRequestApprovalCommandHandler(ILogger<FriendRequestApprovalCommandHandler> logger, IMapper mapper, IChatAppDbContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<Unit> Handle(FriendRequestApprovalCommand request, CancellationToken cancellationToken)
        {
            FriendRequestEntity friendRequest = await _context.FriendRequests.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == request.FriendRequestId);

            if (friendRequest == null)
            {
                throw new NotFoundException(nameof(FriendRequestEntity), request.FriendRequestId);
            }

            friendRequest.Accepted = request.Approved;

            if (request.Approved)
            {
                FriendEntity friendEntity = new FriendEntity { UserId = friendRequest.User.Id, FriendId = friendRequest.RequestedUserId };
                friendRequest.User.Friends.Add(friendEntity);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
