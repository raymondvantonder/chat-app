using ChatApp.Application.Common.Exceptions;
using ChatApp.Application.Interfaces;
using ChatApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp.Application.Users.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResultDto>
    {
        private readonly ILogger<LoginCommandHandler> _logger;
        private readonly IChatAppDbContext _context;

        public LoginCommandHandler(ILogger<LoginCommandHandler> logger, IChatAppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<LoginResultDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            UserEntity user = await _context.Users.FirstOrDefaultAsync(x => x.Password == request.Password && x.Email == request.Email);

            var loginResult = new LoginResultDto();

            if (user == null)
            {
                _logger.LogWarning($"Invalid login request for {user.Email}");

                loginResult.Success = false;

                return loginResult;
            }

            //Implement JWT token stuff
            loginResult.Success = true;

            return loginResult;
        }
    }
}
