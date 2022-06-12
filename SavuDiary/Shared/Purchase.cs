using System.ComponentModel.DataAnnotations.Schema;

namespace SavuDiary.Shared
{
    public class Purchase:Base
    {
        public DateTime DateTime { get; set; }
        public Guid CustomerId { get; set; }
        public Decimal Amount { get; set; }
        public Decimal DiscountAmount { get; set; }
        public Decimal NetAmount { get; set; }
        public string Notes { get; set; }

        [NotMapped]
        public string CustomerName { get; set; }
    }
}
