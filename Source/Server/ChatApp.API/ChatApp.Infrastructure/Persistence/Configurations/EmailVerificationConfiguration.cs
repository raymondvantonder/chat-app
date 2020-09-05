using ChatApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Infrastructure.Persistence.Configurations
{
    public class EmailVerificationConfiguration : IEntityTypeConfiguration<EmailVerificationEntity>
    {
        public void Configure(EntityTypeBuilder<EmailVerificationEntity> builder)
        {
            
        }
    }
}
