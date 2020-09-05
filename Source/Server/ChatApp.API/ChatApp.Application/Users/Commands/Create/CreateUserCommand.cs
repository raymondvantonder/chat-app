using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.Users.Commands.Create
{
    public class CreateUserCommand : IRequest<long>
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
