using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.Chats.Commands.Create
{
    public class CreateChatCommand : IRequest<long>
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public long CreatorId { get; set; }
        public IEnumerable<long> Users { get; set; }
    }
}
