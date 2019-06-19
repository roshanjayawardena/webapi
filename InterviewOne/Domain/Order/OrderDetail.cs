using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Order
{
    [Table("OrderDetail")]
    public class OrderDetail:BaseDomain
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public double Amount { get; set; }
        public double Discount { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }

    }
}
