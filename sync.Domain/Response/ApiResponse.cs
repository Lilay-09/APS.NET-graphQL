using System.Net;

namespace sync.Domain.Response
{
    public class ApiResponse<T> where T : class
    {
        public HttpStatusCode? StatusCode { get; set; } = HttpStatusCode.OK;
        public T? Data { get; set; } = null;
        public string? Message { get; set; } = null;
        public bool? IsSuccess { get; set; } = true;
        public ApiResponse() { }
        public ApiResponse(
                T? data,
                string? message,
                bool? isSuccess
            )
        {
            Data = data;
            Message = message;
            IsSuccess = isSuccess;
        }

    }
}
