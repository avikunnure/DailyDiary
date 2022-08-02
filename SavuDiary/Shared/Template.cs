using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavuDiary.Shared
{
    public class Template :Base
    {
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public Decimal Quantity { get; set; } = 0;
        public DateTime ApplicableDatetime { get; set; } = DateTime.Now;

        [NotMapped]
        public string ProductName { get; set; } = "";
        [NotMapped]
        public string CustomerName { get; set; } = "";
    }
}
