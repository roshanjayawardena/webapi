using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Order
{
    [Table("Invoice")]
    public class Invoice:BaseDomain
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }
        public double TotalAmount { get; set; }
        public double DiscountAmount { get; set; }
    }
}
