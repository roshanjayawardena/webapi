using Service.Bo.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Bo
{
    public class CustomerBo:BaseBo
    {
        public new int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
