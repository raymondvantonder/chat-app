using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ChatApp.Application.Chats;
using ChatApp.Application.Chats.Queries.GetAll;
using ChatApp.Application.Firends.Commands.AddFriend;
using ChatApp.Application.Friends;
using ChatApp.Application.Friends.Queries.GetFriendRequests;
using ChatApp.Application.Friends.Queries.GetFriends;
using ChatApp.Application.Users.Commands;
using ChatApp.Application.Users.Commands.Create;
using ChatApp.Application.Users.Queries;
using ChatApp.Application.Users.Queries.ByEmail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.API.Controllers
{
    [Route("api/v1/user")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("friends/requests/{userId}")]
        public Task<IEnumerable<FriendRequestDto>> GetPendingFriendRequests(long userId)
        {
            return _mediator.Send(new GetFriendRequestsQuery { UserId = userId });
        }

        [HttpGet("friends/{userId}")]
        public Task<IEnumerable<FriendDto>> GetFriends(long userId)
        {
            return _mediator.Send(new GetFriendsQuery { Id = userId });
        }

        [HttpPost("friends")]
        public Task<long> AddFriend(AddFriendCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpGet("chats/{userId}")]
        public Task<IEnumerable<ChatVm>> GetUser(long userId)
        {
            return _mediator.Send(new GetChatsQuery() { UserId = userId });
        }

        [HttpGet("{email}")]
        public Task<UserDto> GetUser(string email)
        {
            return _mediator.Send(new UserByEmailQuery() { Email = email });
        }

        [HttpPost]
        public Task<long> CreateUser(CreateUserCommand command)
        {
            return _mediator.Send(command);
        }
    }
}
