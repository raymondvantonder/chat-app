using ChatApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ChatApp.Infrastructure.Persistence.Configurations
{
    public class FriendConfiguration : IEntityTypeConfiguration<FriendEntity>
    {
        public void Configure(EntityTypeBuilder<FriendEntity> builder)
        {
            builder.HasOne(x => x.User).WithMany(x => x.Friends);
            builder.HasOne(x => x.Friend);
        }
    }
}
