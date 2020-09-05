using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.Chats.Queries.GetAll
{
    public class GetChatsQuery : IRequest<IEnumerable<ChatVm>>
    {
        public long UserId { get; set; }
    }
}
