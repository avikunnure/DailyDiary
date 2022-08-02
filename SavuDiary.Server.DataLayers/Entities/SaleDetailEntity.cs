using SavuDiary.Shared;
using System.ComponentModel.DataAnnotations.Schema;
namespace SavuDiary.Server.DataLayers
{
    public class SaleDetailEntity:BaseEntity
    {
        public Guid SaleId { get; set; }
        public Guid ProductId { get; set; }
        public Decimal Price { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal StockQuantity { get; set; }
        public Decimal TotalAmount { get; set; }
        public Decimal Discount { get; set; }
        public Decimal NetAmount { get; set; }

        [NotMapped]
        public string ProductName { get; set; } = "";

        [NotMapped]
        public List<TaxRecordDetailEntity> TaxRecordDetailEntity { get; set; }

        public static implicit operator SaleDetailEntity(SaleDetail saleDetail)
        {
            return new SaleDetailEntity()
            {
                IsActive = saleDetail.IsActive,
                SaleId = saleDetail.SaleId,
                ProductId = saleDetail.ProductId,
                Price = saleDetail.Price,
                Quantity = saleDetail.Quantity,
                TotalAmount = saleDetail.TotalAmount,
                Discount = saleDetail.Discount,
                NetAmount = saleDetail.NetAmount,
                ProductName = saleDetail.ProductName,
                Id=saleDetail.Id,
                TaxRecordDetailEntity = saleDetail.TaxRecordDetails != null ?
                    saleDetail.TaxRecordDetails.Select(x => (TaxRecordDetailEntity)x).ToList()
                    : new List<TaxRecordDetailEntity>(),
            };
        }
        public static implicit operator SaleDetail(SaleDetailEntity saleDetail)
        {
            return new SaleDetail()
            {
                IsActive = saleDetail.IsActive,
                SaleId = saleDetail.SaleId,
                ProductId = saleDetail.ProductId,
                Price = saleDetail.Price,
                Quantity = saleDetail.Quantity,
                TotalAmount = saleDetail.TotalAmount,
                Discount = saleDetail.Discount,
                NetAmount = saleDetail.NetAmount,
                ProductName = saleDetail.ProductName,
                Id = saleDetail.Id,
                TaxRecordDetails = saleDetail.TaxRecordDetailEntity != null ?
                    saleDetail.TaxRecordDetailEntity.Select(x => (TaxRecordDetails)x).ToList()
                    : new List<TaxRecordDetails>(),
            };
        }
    }
}
