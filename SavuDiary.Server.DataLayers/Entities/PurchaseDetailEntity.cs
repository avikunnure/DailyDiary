using SavuDiary.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SavuDiary.Server.DataLayers
{
    public class PurchaseDetailEntity:BaseEntity
    {
        public Guid PurchaseId { get; set; }
        public Guid ProductId { get; set; }
        public Decimal Price { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal TotalAmount { get; set; }
        public Decimal Discount { get; set; }
        public Decimal NetAmount { get; set; }

        [NotMapped]
        public string ProductName { get; set; }

        public static implicit operator PurchaseDetailEntity(PurchaseDetail purchaseDetail)
        {
            return new PurchaseDetailEntity()
            {
                Discount = purchaseDetail.Discount,
                NetAmount = purchaseDetail.NetAmount,
                ProductName = purchaseDetail.ProductName,
                Price = purchaseDetail.Price,
                Id = purchaseDetail.Id,
                ProductId = purchaseDetail.ProductId,
                IsActive = purchaseDetail.IsActive,
                PurchaseId = purchaseDetail.PurchaseId,
                Quantity = purchaseDetail.Quantity,
                TotalAmount = purchaseDetail.TotalAmount,

            };
        }

        public static implicit operator PurchaseDetail(PurchaseDetailEntity purchaseDetail)
        {
            return new PurchaseDetail()
            {
                Discount = purchaseDetail.Discount,
                NetAmount = purchaseDetail.NetAmount,
                ProductName = purchaseDetail.ProductName,
                Price = purchaseDetail.Price,
                Id = purchaseDetail.Id,
                ProductId = purchaseDetail.ProductId,
                IsActive = purchaseDetail.IsActive,
                PurchaseId = purchaseDetail.PurchaseId,
                Quantity = purchaseDetail.Quantity,
                TotalAmount = purchaseDetail.TotalAmount,

            };
        }
    }
}
