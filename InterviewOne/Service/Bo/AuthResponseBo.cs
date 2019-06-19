using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Bo
{
    public class AuthResponseBo
    {

        public string Token { get; set; }
        public DateTime? TokenExpiration { get; set; }
        public bool IsAdmin { get; set; }
      

    }
}
