using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.Users.Commands.Login
{
    public class LoginResultDto
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpiryTime { get; set; }
    }
}
