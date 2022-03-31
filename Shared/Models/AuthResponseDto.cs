namespace HandsOnWithBlazor.Shared.Models
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public bool IsAuthSuccessful => !string.IsNullOrEmpty(Token);
    }
}
