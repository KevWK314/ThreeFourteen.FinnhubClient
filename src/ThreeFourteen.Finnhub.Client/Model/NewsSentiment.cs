using Newtonsoft.Json;

namespace ThreeFourteen.Finnhub.Client.Model
{
    public class NewsSentiment
    {
        [JsonProperty("buzz")]
        public SentimentBuzz Buzz { get; set; }

        [JsonProperty("companyNewsScore")]
        public double CompanyNewsScore { get; set; }

        [JsonProperty("sectorAverageBullishPercent")]
        public double SectorAverageBullishPercent { get; set; }

        [JsonProperty("sectorAverageNewsScore")]
        public double SectorAverageNewsScore { get; set; }

        [JsonProperty("sentiment")]
        public Sentiment Sentiment { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }

    public class SentimentBuzz
    {
        [JsonProperty("articlesInLastWeek")]
        public long ArticlesInLastWeek { get; set; }

        [JsonProperty("buzz")]
        public double Buzz { get; set; }

        [JsonProperty("weeklyAverage")]
        public double WeeklyAverage { get; set; }
    }

    public class Sentiment
    {
        [JsonProperty("bearishPercent")]
        public double BearishPercent { get; set; }

        [JsonProperty("bullishPercent")]
        public double BullishPercent { get; set; }
    }
}
