using SavuDiary.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SavuDiary.Server.DataLayers
{
    public class SaleEntity:BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SaleNo { get; set; }
        public DateTime SaleDateTime { get; set; }
        public Guid CustomerId { get; set; }
        public Decimal SaleAmount { get; set; }
        public Decimal DiscountAmount { get; set; }
        public Decimal NetAmount { get; set; }
        public bool IsReturn { get; set; }
        public bool ReturnReasons { get; set; }
        public string Notes { get; set; } = "";

        [NotMapped]
        public string CustomerName { get; set; } = "";

        public static implicit operator SaleEntity(Sale sale)
        {
            return new SaleEntity()
            {
                SaleDateTime = sale.SaleDateTime,
                SaleAmount = sale.SaleAmount,
                DiscountAmount = sale.DiscountAmount,
                NetAmount = sale.NetAmount,
                IsReturn = sale.IsReturn,
                ReturnReasons = sale.ReturnReasons,
                Notes = sale.Notes,
                CustomerName = sale.CustomerName,
                CustomerId = sale.CustomerId,
                Id = sale.Id,
                IsActive = sale.IsActive,
                SaleNo=sale.SaleNo,
            };
        }
        public static implicit operator Sale(SaleEntity sale)
        {
            return new Sale()
            {
                SaleDateTime = sale.SaleDateTime,
                SaleAmount = sale.SaleAmount,
                DiscountAmount = sale.DiscountAmount,
                NetAmount = sale.NetAmount,
                IsReturn = sale.IsReturn,
                ReturnReasons = sale.ReturnReasons,
                Notes = sale.Notes,
                CustomerName = sale.CustomerName,
                CustomerId = sale.CustomerId,
                Id = sale.Id,
                IsActive = sale.IsActive,
                SaleNo=sale.SaleNo,
            };
        }
    }
}
