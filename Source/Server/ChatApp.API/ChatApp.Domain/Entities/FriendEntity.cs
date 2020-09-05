using ChatApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Domain.Entities
{
    public class FriendEntity : AuditableEntity
    {
        public long Id { get; set; }

        //Foreign Keys
        public long UserId { get; set; }
        public long FriendId { get; set; }

        public UserEntity User { get; set; }
        public UserEntity Friend { get; set; }
    }
}
