using System;

namespace Domain.Models
{

    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
    }
}


