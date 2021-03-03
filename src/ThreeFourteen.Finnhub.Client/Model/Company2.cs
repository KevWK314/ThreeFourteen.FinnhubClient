using Newtonsoft.Json;

namespace ThreeFourteen.Finnhub.Client.Model
{
    public class Company2
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("exchange")]
        public string Exchange { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ticker")]
        public string Ticker { get; set; }

        [JsonProperty("ipo")]
        public string IPO { get; set; }

        [JsonProperty("marketCapitalization")]
        public string MarketCapitalization { get; set; }

        [JsonProperty("sharesOutstanding")]
        public string SharesOutstanding { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("finnhubindustry")]
        public string FinnHubIndustry { get; set; }

        [JsonProperty("weburl")]
        public string Weburl { get; set; }
    }
}
