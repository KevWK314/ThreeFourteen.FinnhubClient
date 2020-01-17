using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace ThreeFourteen.Finnhub.Client.Model
{
    public class NewsEntry
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("datetime")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Datetime { get; set; }

        [JsonProperty("headline")]
        public string Headline { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("image")]
        public Uri Image { get; set; }

        [JsonProperty("related")]
        public string Related { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

}
