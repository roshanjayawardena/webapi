using Service.Bo.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Bo
{
    public class ProductBo :BaseBo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
