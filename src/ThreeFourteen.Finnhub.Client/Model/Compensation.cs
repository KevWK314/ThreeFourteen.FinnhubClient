using Newtonsoft.Json;

namespace ThreeFourteen.Finnhub.Client.Model
{
    public class Compensation
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("salary")]
        public int Salary { get; set; }

        [JsonProperty("bonus")]
        public int Bonus { get; set; }

        [JsonProperty("stockAwards")]
        public int StockAwards { get; set; }

        [JsonProperty("optionAwards")]
        public int OptionAwards { get; set; }

        [JsonProperty("nonEquityIncentives")]
        public long NonEquityIncentives { get; set; }

        [JsonProperty("pensionAndDeferred")]
        public int PensionAndDeferred { get; set; }

        [JsonProperty("otherComp")]
        public int OtherComp { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("year")]
        public string Year { get; set; }
    }
}
