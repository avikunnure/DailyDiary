using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SavuDiary.Shared
{
    public class PurchaseDetail:Base
    {
        public Guid PurchaseId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public Decimal Price { get; set; }
        [Required]
        [Range(1,double.MaxValue)]
        public Decimal Quantity { get; set; } = 1;
        [Required]
        public Decimal TotalAmount { get; set; }
        [Required]
        public Decimal Discount { get; set; }
        [Required]
        public Decimal NetAmount { get; set; }

        [NotMapped]
        public string ProductName { get; set; } = "";
    }
}
