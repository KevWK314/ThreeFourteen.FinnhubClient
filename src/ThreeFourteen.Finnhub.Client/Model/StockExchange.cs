using Newtonsoft.Json;

namespace ThreeFourteen.Finnhub.Client.Model
{
    public class StockExchange
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
