using ChatApp.Application.Common.Exceptions;
using ChatApp.Application.Interfaces;
using ChatApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp.Application.Users.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
    {
        private readonly IChatAppDbContext _context;
        private readonly ILogger<CreateUserCommand> _logger;

        public CreateUserCommandHandler(ILogger<CreateUserCommand> logger, IChatAppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            UserEntity userByEmail = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);

            if (userByEmail != null)
            {
                _logger.LogError($"A user with email {request.Email} already exists!");
                throw new DuplicateUserException(request.Email);
            }

            UserEntity userByNickname = await _context.Users.FirstOrDefaultAsync(x => x.Nickname == request.Nickname);

            if (userByEmail != null)
            {
                _logger.LogError($"A user with nickname {request.Nickname} already exists!");
                throw new DuplicateUserException(request.Nickname);
            }

            var userEntity = new UserEntity
            {
                Email = request.Email,
                DateOfBirth = request.DateOfBirth,
                Name = request.Name,
                Password = request.Password,
                Nickname = request.Nickname
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync(cancellationToken);

            return userEntity.Id;
        }
    }
}
