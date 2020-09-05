using ChatApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Domain.Entities
{
    public class MessageEntity : AuditableEntity
    {
        public long Id { get; set; }
        public string Message { get; set; }

        //Foreign Key
        public long ChatId { get; set; }
        public long SenderId { get; set; }

        public ChatEntity Chat { get; set; }
        public UserEntity Sender { get; set; }
    }
}
