using System.ComponentModel.DataAnnotations.Schema;
namespace SavuDiary.Shared
{
    public class SaleDetail:Base
    {
        public Guid SaleId { get; set; }
        public Guid ProductId { get; set; }
        public Decimal Price { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal TotalAmount { get; set; }
        public Decimal Discount { get; set; }
        public Decimal NetAmount { get; set; }

        public List<TaxRecordDetails> TaxRecordDetails { get; set; }

        [NotMapped]
        public string ProductName { get; set; } = "";
    }
}
