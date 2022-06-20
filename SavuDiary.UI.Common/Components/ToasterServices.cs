namespace SavuDiary.Client.Components
{
    public class ToasterItem
    {
        public ToastLevel ToastLevel { get; set; }
        public string Text { get; set; }
        public bool IsVisible { get; set; } = true;
        public DateTime dateTime { get; set; }
    }
    public enum ToastLevel
    {
        Info,
        Success,
        Warning,
        Error
    }

    public class ToasterServices
    {
        public event Action UpdateListEvents;
        public void ShowToaster(string Message, ToastLevel toastLevel)
        {
            ListOfToasters.ToasterItems.Add(new ToasterItem() { IsVisible = true, Text = Message, ToastLevel = toastLevel ,dateTime=DateTime.Now});
            UpdateListEvents?.Invoke();
        }
        public void RemoveInActive() => ListOfToasters.ToasterItems.RemoveAll(x => x.IsVisible == false);
    }
    public static class ListOfToasters
    {
        public static List<ToasterItem> ToasterItems { get; set; } = new List<ToasterItem> { };
    }
}
