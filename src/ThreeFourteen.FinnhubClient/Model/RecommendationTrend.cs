using Newtonsoft.Json;

namespace ThreeFourteen.FinnhubClient.Model
{
    public class RecommendationTrend
    {
        [JsonProperty("buy")]
        public int Buy { get; set; }

        [JsonProperty("hold")]
        public int Hold { get; set; }

        [JsonProperty("period")]
        public string Period { get; set; }

        [JsonProperty("sell")]
        public int Sell { get; set; }

        [JsonProperty("strongBuy")]
        public int StrongBuy { get; set; }

        [JsonProperty("strongSell")]
        public int StrongSell { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }
}
