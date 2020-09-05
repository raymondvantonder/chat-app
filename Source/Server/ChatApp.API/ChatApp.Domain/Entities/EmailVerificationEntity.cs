using ChatApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Domain.Entities
{
    public class EmailVerificationEntity : AuditableEntity
    {
        public long Id { get; set; }
        public string VerificationCode { get; set; }
        public DateTime SentTime { get; set; }
        public bool ResponseReceived { get; set; }
        public DateTime ResponseReceivedTime { get; set; }

        //Foreign Keys
        public long UserId { get; set; }

        public UserEntity User { get; set; }
    }
}
