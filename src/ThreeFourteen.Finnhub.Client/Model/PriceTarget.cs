using Newtonsoft.Json;
using System;

namespace ThreeFourteen.Finnhub.Client.Model
{
    public class PriceTarget
    {
        [JsonProperty("lastUpdated")]
        public DateTime LastUpdated { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("targetHigh")]
        public double TargetHigh { get; set; }

        [JsonProperty("targetLow")]
        public double TargetLow { get; set; }

        [JsonProperty("targetMean")]
        public double TargetMean { get; set; }

        [JsonProperty("targetMedian")]
        public double TargetMedian { get; set; }
    }
}
