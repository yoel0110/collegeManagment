namespace cm.api
{
    public class ApiResponse<T> where T : class
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Sucess { get; set; }
        public int StatusCode { get; set; }

        public static ApiResponse<T> SuccessResponse(T data, string message=null, int statusCode = 200)
        {
            return new ApiResponse<T>
            {
                Data = data,
                Message = message,
                StatusCode = statusCode,
                Sucess =  true 
            };
        }

        public static ApiResponse<T> UnSuccessFullResponse(string message = null, int statusCode = 500) 
        {
            return new ApiResponse<T>
            {
                Message = message,
                StatusCode = statusCode,
                Sucess = false
            };
        }
    }
}
