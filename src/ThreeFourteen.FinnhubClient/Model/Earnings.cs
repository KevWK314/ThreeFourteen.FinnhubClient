using Newtonsoft.Json;
using System;

namespace ThreeFourteen.FinnhubClient.Model
{
    public class Earnings
    {
        [JsonProperty("actual")]
        public double Actual { get; set; }

        [JsonProperty("estimate")]
        public double Estimate { get; set; }

        [JsonProperty("period")]
        public DateTime Period { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }
}
