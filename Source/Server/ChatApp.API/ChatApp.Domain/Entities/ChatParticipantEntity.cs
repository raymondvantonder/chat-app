using ChatApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Domain.Entities
{
    public class ChatParticipantEntity : AuditableEntity
    {
        public long Id { get; set; }
        public long ChatId { get; set; }
        public long UserId { get; set; }

        public ChatEntity Chat { get; set; }
        public UserEntity User { get; set; }
    }
}
