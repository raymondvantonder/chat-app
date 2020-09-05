using ChatApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Domain.Entities
{
    public class UserEntity : AuditableEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public IList<EmailVerificationEntity> EmailVerification { get; set; } = new List<EmailVerificationEntity>();
        public IList<FriendRequestEntity> FriendRequests { get; set; } = new List<FriendRequestEntity>();
        public IList<FriendEntity> Friends { get; set; } = new List<FriendEntity>();
        public IList<ChatEntity> Chats { get; set; } = new List<ChatEntity>();
    }
}
