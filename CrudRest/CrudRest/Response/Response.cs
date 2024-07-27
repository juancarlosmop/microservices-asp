namespace CrudRest.Response
{
    public class Response<T>
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public Response(string status, string message, T data)
        {
            Status = status;
            Message = message;
            Data = data;
        }
    }
}
