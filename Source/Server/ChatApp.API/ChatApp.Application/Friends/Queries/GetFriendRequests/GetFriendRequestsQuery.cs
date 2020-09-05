using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.Friends.Queries.GetFriendRequests
{
    public class GetFriendRequestsQuery : IRequest<IEnumerable<FriendRequestDto>>
    {
        public long UserId { get; set; }
    }
}
