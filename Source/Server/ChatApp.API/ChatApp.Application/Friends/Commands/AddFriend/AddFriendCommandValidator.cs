using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.Firends.Commands.AddFriend
{
    public class AddFriendCommandValidator : AbstractValidator<AddFriendCommand>
    {
        public AddFriendCommandValidator()
        {
            RuleFor(x => x.RequestingUserId).GreaterThan(0);
            RuleFor(x => x.UserToAddId).GreaterThan(0);
        }
    }
}
