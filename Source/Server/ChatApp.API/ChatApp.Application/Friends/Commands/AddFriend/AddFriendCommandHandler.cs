using ChatApp.Application.Interfaces;
using ChatApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp.Application.Firends.Commands.AddFriend
{
    public class AddFriendCommandHandler : IRequestHandler<AddFriendCommand, long>
    {
        private readonly ILogger<AddFriendCommandHandler> _logger;
        private readonly IChatAppDbContext _context;

        public AddFriendCommandHandler(ILogger<AddFriendCommandHandler> logger, IChatAppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<long> Handle(AddFriendCommand request, CancellationToken cancellationToken)
        {
            UserEntity requestingUser = await _context.Users.Include(x => x.Friends).Include(x => x.FriendRequests).FirstOrDefaultAsync(x => x.Id == request.RequestingUserId);

            if (requestingUser.Friends.Any(x => x.FriendId == request.UserToAddId))
            {
                throw new Exception("User is already a friend");
            }

            UserEntity user = await _context.Users.FindAsync(request.UserToAddId);

            FriendRequestEntity existingFriendRequest = user.FriendRequests.FirstOrDefault(x => x.Accepted == null && x.RequestedUserId == request.UserToAddId);

            if (existingFriendRequest != null)
            {
                return existingFriendRequest.Id;
            }

            var friendRequest = new FriendRequestEntity()
            {
                UserId = request.UserToAddId,
                RequestedUserId = request.RequestingUserId,
                Message = request.Message
            };

            user.FriendRequests.Add(friendRequest);

            await _context.SaveChangesAsync(cancellationToken);

            return friendRequest.Id;
        }
    }
}
