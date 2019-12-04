using Newtonsoft.Json;
using System.Collections.Generic;

namespace ThreeFourteen.Finnhub.Client.Model
{

    public class CandleData
    {
        [JsonProperty("c")]
        public List<double> Close { get; set; }

        [JsonProperty("h")]
        public List<double> High { get; set; }

        [JsonProperty("l")]
        public List<double> Low { get; set; }

        [JsonProperty("o")]
        public List<double> Open { get; set; }

        [JsonProperty("s")]
        public string Status { get; set; }

        [JsonProperty("t")]
        public List<long> Timestamp { get; set; }

        [JsonProperty("v")]
        public List<int> Volume { get; set; }
    }
}
