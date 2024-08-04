namespace Papara_cohort.Base.Response
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        public ApiResponse()
        {
            Success = true;
        }

        public ApiResponse(T data) : this()
        {
            Data = data;
        }

        public ApiResponse(string message)
        {
            Success = false;
            Message = message;
        }
    }

    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public ApiResponse()
        {
            Success = true;
        }

        public ApiResponse(string message)
        {
            Success = false;
            Message = message;
        }
    }
}
