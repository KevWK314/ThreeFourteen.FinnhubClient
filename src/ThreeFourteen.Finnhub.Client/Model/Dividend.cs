using Newtonsoft.Json;
using System;

namespace ThreeFourteen.Finnhub.Client.Model
{
    public class Dividend
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }
    }
}
