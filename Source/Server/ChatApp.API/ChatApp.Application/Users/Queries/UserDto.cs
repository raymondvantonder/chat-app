using ChatApp.Application.Common.Mappings;
using ChatApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.Users.Queries
{
    public class UserDto : IMapFrom<UserEntity>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
