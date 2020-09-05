using ChatApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp.Application.Interfaces
{
    public interface IChatAppDbContext
    {
        DbSet<UserEntity> Users { get; set; }
        DbSet<EmailVerificationEntity> EmailVerifications { get; set; }
        DbSet<FriendEntity> Friends { get; set; }
        DbSet<FriendRequestEntity> FriendRequests { get; set; }
        DbSet<ChatEntity> Chats { get; set; }
        DbSet<MessageEntity> Messages { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
