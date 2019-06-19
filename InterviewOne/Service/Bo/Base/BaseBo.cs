using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Bo.Base
{
    public class BaseBo
    {
        public int Id { get; set; }
        public Common.Enums.RecordStatus RecordStatus { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedById { get; set; }
        public int? EditedById { get; set; }
        public DateTime? EditedOn { get; set; }

    }
}
