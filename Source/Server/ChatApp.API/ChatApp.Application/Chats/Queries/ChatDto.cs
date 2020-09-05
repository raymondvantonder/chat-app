using ChatApp.Application.Common.Mappings;
using ChatApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.Chats.Queries
{
    public class ChatDto : IMapFrom<ChatEntity>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long CreatorId { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
