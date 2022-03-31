namespace HandsOnWithBlazor.Shared.Models
{
    public struct ApiResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }

        public ApiResponse(string status, string message)
        {
            Status = status; ;
            Message = message;            
        }
    }

    public struct ApiResponse<T> where T : class
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse(string status, string message, T data)
        {
            Status = status; ;
            Message = message;
            Data = data;
        }
    }
}
