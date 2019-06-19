using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Order
{
    [Table("Order")]
    public class Order : BaseDomain
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderedDate { get; set; }

        public Customer.Customer Customer { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
