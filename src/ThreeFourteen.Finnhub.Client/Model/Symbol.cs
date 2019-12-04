using Newtonsoft.Json;

namespace ThreeFourteen.Finnhub.Client.Model
{
    public partial class Symbol
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("hasWM")]
        public bool HasWm { get; set; }

        [JsonProperty("displaySymbol")]
        public string DisplaySymbol { get; set; }

        [JsonProperty("symbol")]
        public string CandleSymbol { get; set; }
    }
}
