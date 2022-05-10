using System.Net.Http;

namespace Clean.ProductionPlanner.MVC.Services.Base
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }

    }
}
