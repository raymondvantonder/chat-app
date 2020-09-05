using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.Users.Commands.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Nickname).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEqual(default(DateTime));
        }
    }
}
