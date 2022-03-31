namespace HandsOnWithBlazor.Client.Models
{
    public struct SimpleStateModel
    {
        public bool IsToggle { get; set; }
        public string Token {get;set;}
        public string RefreshToken { get; set; }

        public SimpleStateModel() {
            IsToggle = false;
            Token = String.Empty; 
            RefreshToken = String.Empty;
        }
    }
}