using SavuDiary.Shared;

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
            };
        }
    }
}
