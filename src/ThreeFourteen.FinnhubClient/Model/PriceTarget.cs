using Newtonsoft.Json;
using System;

namespace ThreeFourteen.FinnhubClient.Model
{
    public class PriceTarget
    {
        [JsonProperty("lastUpdated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("targetHigh")]
        public long TargetHigh { get; set; }

        [JsonProperty("targetLow")]
        public long TargetLow { get; set; }

        [JsonProperty("targetMean")]
        public double TargetMean { get; set; }

        [JsonProperty("targetMedian")]
        public double TargetMedian { get; set; }
    }
}
