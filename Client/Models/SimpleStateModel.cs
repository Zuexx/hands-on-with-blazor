namespace HandsOnWithBlazor.Client.Models
{
    public struct SimpleStateModel
    {
        public bool IsToggle { get; set; }

        public SimpleStateModel() {
            IsToggle = false;
        }
    }
}