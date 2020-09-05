using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.Users.Commands.Login
{
    public class LoginCommand : IRequest<LoginResultDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
