using ChatApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Infrastructure.Persistence.Configurations
{
    public class FriendRequestConfiguration : IEntityTypeConfiguration<FriendRequestEntity>
    {
        public void Configure(EntityTypeBuilder<FriendRequestEntity> builder)
        {
            builder.HasOne(x => x.User).WithMany(x => x.FriendRequests);
            builder.HasOne(x => x.RequestedUser);
        }
    }
}
