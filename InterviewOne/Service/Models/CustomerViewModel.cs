using Service.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Models
{
    public class CustomerViewModel:BaseViewModel
    {

        public new int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
