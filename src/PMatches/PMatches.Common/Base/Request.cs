namespace PMatches.Presentation.Responses
{
    public class Request<T> where T : class
    {  
        public T Data { get; set; }
    }
}
