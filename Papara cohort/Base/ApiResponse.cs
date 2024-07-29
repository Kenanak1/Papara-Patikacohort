public class ApiResponse<T>
{
    public T Data { get; set; }
    public List<string> Errors { get; set; }
    public bool Success { get; set; }

    public ApiResponse(T data)
    {
        Data = data;
        Success = true;
    }

    public ApiResponse(List<string> errors)
    {
        Errors = errors;
        Success = false;
    }
}
