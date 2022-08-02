namespace SavuDiary.Shared
{
    public class StockMangement : Base
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

        public string ProductName { get; set; } = "";
    }
}
