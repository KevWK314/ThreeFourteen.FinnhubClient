using System;

namespace ThreeFourteen.FinnhubClient
{
    public class FinnhubConfig
    {
        public Uri BaseUri { get; set; } = new Uri("https://finnhub.io/api/v1");

        public string ApiKey { get; set; }
    }
}
