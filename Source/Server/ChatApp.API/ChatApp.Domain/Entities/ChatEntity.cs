using ChatApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Domain.Entities
{
    public class ChatEntity : AuditableEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long CreatorId { get; set; }

        public IList<MessageEntity> Messages { get; set; } = new List<MessageEntity>();
        public IList<ChatParticipantEntity> ChatParticipants { get; set; } = new List<ChatParticipantEntity>();
        public UserEntity Creator { get; set; }
    }
}
