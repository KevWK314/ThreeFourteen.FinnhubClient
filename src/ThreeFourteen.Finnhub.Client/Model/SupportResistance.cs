using Newtonsoft.Json;
using System.Collections.Generic;

namespace ThreeFourteen.Finnhub.Client.Model
{
    public class SupportResistance
    {
        [JsonProperty("levels")]
        public List<double> Levels { get; set; }
    }
}
