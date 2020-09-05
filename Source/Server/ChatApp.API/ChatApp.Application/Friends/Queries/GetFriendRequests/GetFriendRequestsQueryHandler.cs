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

namespace ChatApp.Application.Friends.Queries.GetFriendRequests
{
    public class GetFriendRequestsQueryHandler : IRequestHandler<GetFriendRequestsQuery, IEnumerable<FriendRequestDto>>
    {
        private readonly ILogger<GetFriendRequestsQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IChatAppDbContext _context;

        public GetFriendRequestsQueryHandler(ILogger<GetFriendRequestsQueryHandler> logger, IMapper mapper, IChatAppDbContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<FriendRequestDto>> Handle(GetFriendRequestsQuery request, CancellationToken cancellationToken)
        {
            return await _context.FriendRequests.Where(x => x.Accepted == null && x.RequestedUserId == request.UserId).ProjectTo<FriendRequestDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
