using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.Users.Queries.ByEmail
{
    public class UserByEmailQueryValidator : AbstractValidator<UserByEmailQuery>
    {
        public UserByEmailQueryValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}
