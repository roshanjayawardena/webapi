using Service.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Models
{
    public class OrderItem: BaseViewModel
    {
        public int ProductId { get; set; }       
        public int Qty { get; set; } 
        public double Amount { get; set; }
        public double Discount { get; set; }
    }
}
