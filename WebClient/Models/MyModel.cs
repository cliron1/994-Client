using System.Net;

namespace WebClient.Models
{
    public class MyModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ServerSideDuration { get; set; }
        public int Count { get; set; }
        public string ListOfWords { get; set; }
    }
}
