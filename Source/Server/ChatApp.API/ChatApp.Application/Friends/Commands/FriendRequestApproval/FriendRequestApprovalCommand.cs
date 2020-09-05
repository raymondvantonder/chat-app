using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.Friends.Commands.FriendRequestApproval
{
    public class FriendRequestApprovalCommand : IRequest
    {
        public long FriendRequestId { get; set; }
        public bool Approved { get; set; }
    }
}
