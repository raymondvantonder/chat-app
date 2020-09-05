using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Domain.Common
{
    public class AuditableEntity
    {
        public DateTime CreatedTime { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
