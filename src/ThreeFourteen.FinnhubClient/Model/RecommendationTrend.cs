using Newtonsoft.Json;

namespace ThreeFourteen.FinnhubClient.Model
{
    public class RecommendationTrend
    {
        [JsonProperty("buy")]
        public long Buy { get; set; }

        [JsonProperty("hold")]
        public long Hold { get; set; }

        [JsonProperty("period")]
        public string Period { get; set; }

        [JsonProperty("sell")]
        public long Sell { get; set; }

        [JsonProperty("strongBuy")]
        public long StrongBuy { get; set; }

        [JsonProperty("strongSell")]
        public long StrongSell { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }
}
