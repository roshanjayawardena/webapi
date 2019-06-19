using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Bo
{
    public class LoginBo
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

    }
}
