using Newtonsoft.Json;

namespace ThreeFourteen.Finnhub.Client.Model
{
    public class Quote
    {
        [JsonProperty("c")]
        public decimal Current { get; set; }

        [JsonProperty("h")]
        public decimal High { get; set; }

        [JsonProperty("l")]
        public decimal Low { get; set; }

        [JsonProperty("o")]
        public decimal Open { get; set; }

        [JsonProperty("pc")]
        public decimal PreviousClose { get; set; }
    }
}
