using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.Firends.Commands.AddFriend
{
    public class AddFriendCommand : IRequest<long>
    {
        public long RequestingUserId { get; set; }
        public long UserToAddId { get; set; }
        public string Message { get; set; }
    }
}
