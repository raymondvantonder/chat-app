using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.Friends.Queries.GetFriends
{
    public class GetFriendsQuery : IRequest<IEnumerable<FriendDto>>
    {
        public long Id { get; set; }
    }
}
