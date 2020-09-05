using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChatApp.Application.Common.Exceptions;
using ChatApp.Application.Interfaces;
using ChatApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp.Application.Users.Queries.ByEmail
{
    public class UserByEmailQueryHandler : IRequestHandler<UserByEmailQuery, UserDto>
    {
        private readonly IChatAppDbContext _context;
        private readonly IMapper _mapper;

        public UserByEmailQueryHandler(IChatAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(UserByEmailQuery request, CancellationToken cancellationToken)
        {
            UserDto user =  await _context.Users.ProjectTo<UserDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);

            if (user == null)
            {
                throw new NotFoundException(nameof(UserEntity), request.Email);
            }

            return user;
        }
    }
}
