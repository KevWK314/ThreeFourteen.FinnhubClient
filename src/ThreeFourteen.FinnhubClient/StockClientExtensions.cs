using System;
using System.Threading.Tasks;
using ThreeFourteen.FinnhubClient.Model;
using ThreeFourteen.FinnhubClient.Serialisation;

namespace ThreeFourteen.FinnhubClient
{
    public static class StockClientExtensions
    {
        public static Task<Company> GetCompany(this StockClient client, string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException(nameof(symbol));

            return client.FinnhubClient.SendAsync<Company>("stock/profile", JsonDeserialiser.Default,
                new Field(FieldKeys.Symbol, symbol));
        }

        public static Task<Compensation> GetCompensation(this StockClient client, string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException(nameof(symbol));

            return client.FinnhubClient.SendAsync<Compensation>("stock/ceo-compensation", JsonDeserialiser.Default,
                new Field(FieldKeys.Symbol, symbol));
        }

        public static Task<RecommendationTrend[]> GetRecommendationTrends(this StockClient client, string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException(nameof(symbol));

            return client.FinnhubClient.SendAsync<RecommendationTrend[]>("stock/recommendation", JsonDeserialiser.Default,
                new Field(FieldKeys.Symbol, symbol));
        }

        public static Task<PriceTarget> GetPriceTarget(this StockClient client, string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException(nameof(symbol));

            return client.FinnhubClient.SendAsync<PriceTarget>("stock/price-target", JsonDeserialiser.Default,
                new Field(FieldKeys.Symbol, symbol));
        }

        public static Task<string[]> GetPeers(this StockClient client, string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException(nameof(symbol));

            return client.FinnhubClient.SendAsync<string[]>("stock/peers", JsonDeserialiser.Default,
                new Field(FieldKeys.Symbol, symbol));
        }

        public static Task<Earnings[]> GetEarnings(this StockClient client, string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException(nameof(symbol));

            return client.FinnhubClient.SendAsync<Earnings[]>("stock/earnings", JsonDeserialiser.Default,
                new Field(FieldKeys.Symbol, symbol));
        }
    }
}
