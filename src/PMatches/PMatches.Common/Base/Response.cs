namespace PMatches.Presentation.Responses
{
    //public class Response<T> where T : class
    //{ 
    //    public bool Success { get; set; }
    //    public string Message { get; set; }
    //    public T Data { get; set; }
    //}
    public class Response<T> where T : class
    {
        public int Id { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
