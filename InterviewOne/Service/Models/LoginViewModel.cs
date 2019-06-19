using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Models
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

    }
}
