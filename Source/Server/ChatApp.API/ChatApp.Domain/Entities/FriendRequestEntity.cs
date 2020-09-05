using ChatApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Domain.Entities
{
    public class FriendRequestEntity : AuditableEntity
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public bool? Accepted { get; set; }

        //Foreign Keys
        public long RequestedUserId { get; set; }
        public long UserId { get; set; }

        public UserEntity User { get; set; }
        public UserEntity RequestedUser { get; set; }
    }
}
