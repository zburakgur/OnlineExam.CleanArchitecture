namespace OnlineExam.Web.Models
{
    public class ResponseData<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
