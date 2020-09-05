using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.Users.Queries.ByEmail
{
    public class UserByEmailQuery : IRequest<UserDto>
    {
        public string Email { get; set; }
    }
}
