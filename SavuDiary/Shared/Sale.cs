using System.ComponentModel.DataAnnotations.Schema;

namespace SavuDiary.Shared
{
    public class Sale:Base
    {
        public DateTime SaleDateTime { get; set; }
        public Guid CustomerId { get; set; }
        public Decimal SaleAmount { get; set; }
        public Decimal DiscountAmount { get; set; }
        public Decimal NetAmount { get; set; }
        public bool IsReturn { get; set; }
        public bool ReturnReasons { get; set; }
        public string Notes { get; set; }

        [NotMapped]
        public string CustomerName { get; set; }
    }
}
