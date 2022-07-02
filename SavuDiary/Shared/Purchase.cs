using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SavuDiary.Shared
{
    public class Purchase : Base
    {
        public long PurchaseNo { get; set; }
        [Required]
        public DateTime DateTime { get; set; } = DateTime.Now;
        [Required]
        public Guid SupplierId { get; set; }
        [Required]
        public Decimal Amount { get; set; }
        [Required]
        public Decimal DiscountAmount { get; set; }
        [Required]
        public Decimal NetAmount { get; set; }
        public string Notes { get; set; } = "";

        [NotMapped]
        public string SupplierName { get; set; } = "";

        public List<PurchaseDetail> PurchaseDetails { get; set; }
        public Purchase()
        {
            PurchaseDetails = new List<PurchaseDetail>();
        }
    }
}
