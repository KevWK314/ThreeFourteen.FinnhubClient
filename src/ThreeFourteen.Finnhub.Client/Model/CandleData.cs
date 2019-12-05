using Newtonsoft.Json;
using System.Collections.Generic;

namespace ThreeFourteen.Finnhub.Client.Model
{

    public class CandleData
    {
        [JsonProperty("c")]
        public List<decimal> Close { get; set; }

        [JsonProperty("h")]
        public List<decimal> High { get; set; }

        [JsonProperty("l")]
        public List<decimal> Low { get; set; }

        [JsonProperty("o")]
        public List<decimal> Open { get; set; }

        [JsonProperty("s")]
        public string Status { get; set; }

        [JsonProperty("t")]
        public List<long> Timestamp { get; set; }

        [JsonProperty("v")]
        public List<long> Volume { get; set; }
    }
}
