using Newtonsoft.Json;

namespace ThreeFourteen.FinnhubClient.Model
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
        public long Salary { get; set; }

        [JsonProperty("bonus")]
        public long Bonus { get; set; }

        [JsonProperty("stockAwards")]
        public long StockAwards { get; set; }

        [JsonProperty("optionAwards")]
        public long OptionAwards { get; set; }

        [JsonProperty("nonEquityIncentives")]
        public long NonEquityIncentives { get; set; }

        [JsonProperty("pensionAndDeferred")]
        public long PensionAndDeferred { get; set; }

        [JsonProperty("otherComp")]
        public long OtherComp { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("year")]
        public long Year { get; set; }
    }
}
