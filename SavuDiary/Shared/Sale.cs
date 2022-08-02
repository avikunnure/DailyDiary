using System.ComponentModel.DataAnnotations.Schema;

namespace SavuDiary.Shared
{
    public class Sale:Base
    {
        public long SaleNo { get; set; }
        public DateTime SaleDateTime { get; set; } = DateTime.Now;
        public Guid CustomerId { get; set; }
        public Decimal SaleAmount { get; set; }
        public Decimal DiscountAmount { get; set; }
        public Decimal NetAmount { get; set; }
        public bool IsReturn { get; set; }
        public bool ReturnReasons { get; set; }
        public string Notes { get; set; } = "";

        [NotMapped]
        public string CustomerName { get; set; } = "";

        public List<SaleDetail> SaleDetailsList { get; set; } = new List<SaleDetail>();
       
    }
}
