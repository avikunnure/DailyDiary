namespace SavuDiary.Shared
{
    public class StockMangement : Base
    {
        public string BatchCode { get; set; }
        public string BarCode { get; set; }
        public string UniqueIdentifier { get; set; }
        public decimal Price { get; set; }
        public decimal Rate { get; set; }
        public DateTime Date { get; set; }

    }
}
