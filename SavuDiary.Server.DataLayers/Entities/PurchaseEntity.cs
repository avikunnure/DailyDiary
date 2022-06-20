using SavuDiary.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SavuDiary.Server.DataLayers
{
    public class PurchaseEntity:BaseEntity
    {
        public DateTime DateTime { get; set; }
        public Guid CustomerId { get; set; }
        public Decimal Amount { get; set; }
        public Decimal DiscountAmount { get; set; }
        public Decimal NetAmount { get; set; }
        public string Notes { get; set; } = "";

        [NotMapped]
        public string CustomerName { get; set; } = "";

        public static implicit operator PurchaseEntity(Purchase purchase)
        {
            return new PurchaseEntity()
            {
                CustomerId = purchase.CustomerId,
                Amount = purchase.Amount,
                DiscountAmount = purchase.DiscountAmount,
                NetAmount = purchase.NetAmount,
                Notes = purchase.Notes,
                CustomerName = purchase.CustomerName,
                DateTime = purchase.DateTime,
                Id = purchase.Id,
                IsActive = purchase.IsActive,
            };
        }
        public static implicit operator Purchase(PurchaseEntity purchase)
        {
            return new Purchase()
            {
                CustomerId = purchase.CustomerId,
                Amount = purchase.Amount,
                DiscountAmount = purchase.DiscountAmount,
                NetAmount = purchase.NetAmount,
                Notes = purchase.Notes,
                CustomerName = purchase.CustomerName,
                DateTime = purchase.DateTime,
                Id = purchase.Id,
                IsActive = purchase.IsActive,
            };
        }
    }
}
