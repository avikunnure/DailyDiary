using SavuDiary.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SavuDiary.Server.DataLayers
{
    public class StockMangementEntity : BaseEntity
    {
        public string BatchCode { get; set; } = "";
        public string BarCode { get; set; } = "";
        public string UniqueIdentifier { get; set; } = "";
        public decimal Price { get; set; }
        public decimal Rate { get; set; }
        public DateTime Date { get; set; }
        public decimal OutQuantity { get; set; }
        public decimal InQuantity { get; set; }
        public Guid ProductId { get; set; }
        public Guid RecordId { get; set; }
        public Guid? RecordDetailId { get; set; }

        [NotMapped]
        public string ProductName { get; set; } = "";


        public static implicit operator StockMangementEntity(StockMangement stockMangement)
        {
            return new StockMangementEntity()
            {
                BatchCode = stockMangement.BatchCode,
                BarCode = stockMangement.BarCode,
                UniqueIdentifier = stockMangement.UniqueIdentifier,
                Price = stockMangement.Price,
                Rate = stockMangement.Rate,
                Date = stockMangement.Date,
                Id = stockMangement.Id,
                IsActive = stockMangement.IsActive,
                InQuantity = stockMangement.InQuantity,
                OutQuantity = stockMangement.OutQuantity,
                ProductId=stockMangement.ProductId,
                ProductName=stockMangement.ProductName,
                RecordDetailId=stockMangement.RecordDetailId,
                RecordId=stockMangement.RecordId,
                

            };
        }

        public static implicit operator StockMangement(StockMangementEntity stockMangement)
        {
            return new StockMangement()
            {
                BatchCode = stockMangement.BatchCode,
                BarCode = stockMangement.BarCode,
                UniqueIdentifier = stockMangement.UniqueIdentifier,
                Price = stockMangement.Price,
                Rate = stockMangement.Rate,
                Date = stockMangement.Date,
                Id = stockMangement.Id,
                IsActive = stockMangement.IsActive,
                InQuantity = stockMangement.InQuantity,
                OutQuantity = stockMangement.OutQuantity,
                ProductId = stockMangement.ProductId,
                ProductName = stockMangement.ProductName,
                RecordDetailId = stockMangement.RecordDetailId,
                RecordId = stockMangement.RecordId,

            };
        }
    }
}
