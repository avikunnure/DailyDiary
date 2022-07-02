using SavuDiary.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SavuDiary.Server.DataLayers
{
    public class PurchaseEntity:BaseEntity
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PurchaseNo { get; set; }
        public DateTime DateTime { get; set; }
        public Guid SupplierId { get; set; }
        public Decimal Amount { get; set; }
        public Decimal DiscountAmount { get; set; }
        public Decimal NetAmount { get; set; }
        public string Notes { get; set; } = "";

        [NotMapped]
        public string SupplierName { get; set; } = "";

        public static implicit operator PurchaseEntity(Purchase purchase)
        {
            
            return new PurchaseEntity()
            {
                SupplierId = purchase.SupplierId,
                Amount = purchase.Amount,
                DiscountAmount = purchase.DiscountAmount,
                NetAmount = purchase.NetAmount,
                Notes = purchase.Notes,
                SupplierName = purchase.SupplierName,
                DateTime = purchase.DateTime,
                Id = purchase.Id,
                IsActive = purchase.IsActive,
                PurchaseNo=purchase.PurchaseNo,
                
                
            };
        }
        public static implicit operator Purchase(PurchaseEntity purchase)
        {
            return new Purchase()
            {
                SupplierId = purchase.SupplierId,
                Amount = purchase.Amount,
                DiscountAmount = purchase.DiscountAmount,
                NetAmount = purchase.NetAmount,
                Notes = purchase.Notes,
                SupplierName = purchase.SupplierName,
                DateTime = purchase.DateTime,
                Id = purchase.Id,
                IsActive = purchase.IsActive,
                PurchaseNo=purchase.PurchaseNo,
            };
        }
    }
}
