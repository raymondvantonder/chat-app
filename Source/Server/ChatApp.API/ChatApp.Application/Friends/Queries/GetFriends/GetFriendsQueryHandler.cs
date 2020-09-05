using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChatApp.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp.Application.Friends.Queries.GetFriends
{
    public class GetFriendsQueryHandler : IRequestHandler<GetFriendsQuery, IEnumerable<FriendDto>>
    {
        private readonly ILogger<GetFriendsQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IChatAppDbContext _context;

        public GetFriendsQueryHandler(ILogger<GetFriendsQueryHandler> logger, IMapper mapper, IChatAppDbContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<FriendDto>> Handle(GetFriendsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Friends.Include(x => x.Friend).Where(x => x.UserId == request.Id).ProjectTo<FriendDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
