using System;
using System.Threading.Tasks;
using ThreeFourteen.Finnhub.Client.Model;
using ThreeFourteen.Finnhub.Client.Serialisation;

namespace ThreeFourteen.Finnhub.Client
{
    public class StockClient
    {
        private readonly FinnhubClient _finnhubClient;

        internal StockClient(FinnhubClient finnhubClient)
        {
            _finnhubClient = finnhubClient;
        }

        public Task<Company> GetCompany(string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException(nameof(symbol));

            return _finnhubClient.SendAsync<Company>("stock/profile", JsonDeserialiser.Default,
                new Field(FieldKeys.Symbol, symbol));
        }

        public Task<Compensation> GetCompensation(string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException(nameof(symbol));

            return _finnhubClient.SendAsync<Compensation>("stock/ceo-compensation", JsonDeserialiser.Default,
                new Field(FieldKeys.Symbol, symbol));
        }

        public Task<RecommendationTrend[]> GetRecommendationTrends(string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException(nameof(symbol));

            return _finnhubClient.SendAsync<RecommendationTrend[]>("stock/recommendation", JsonDeserialiser.Default,
                new Field(FieldKeys.Symbol, symbol));
        }

        public Task<PriceTarget> GetPriceTarget(string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException(nameof(symbol));

            return _finnhubClient.SendAsync<PriceTarget>("stock/price-target", JsonDeserialiser.Default,
                new Field(FieldKeys.Symbol, symbol));
        }

        public Task<string[]> GetPeers(string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException(nameof(symbol));

            return _finnhubClient.SendAsync<string[]>("stock/peers", JsonDeserialiser.Default,
                new Field(FieldKeys.Symbol, symbol));
        }

        public Task<Earnings[]> GetEarnings(string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException(nameof(symbol));

            return _finnhubClient.SendAsync<Earnings[]>("stock/earnings", JsonDeserialiser.Default,
                new Field(FieldKeys.Symbol, symbol));
        }

        public async Task<Candle[]> GetCandles(string symbol, Resolution resolution, int count)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException(nameof(symbol));

            var data = await _finnhubClient.SendAsync<CandleData>("stock/candle", JsonDeserialiser.Default,
                new Field(FieldKeys.Symbol, symbol),
                new Field(FieldKeys.Resolution, resolution.GetFieldValue()),
                new Field(FieldKeys.Count, count.ToString()));

            return data.Map();
        }

        public Task<Candle[]> GetCandles(string symbol, Resolution resolution, DateTime from)
        {
            return GetCandles(symbol, resolution, from, DateTime.UtcNow);
        }

        public async Task<Candle[]> GetCandles(string symbol, Resolution resolution, DateTime from, DateTime to)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException(nameof(symbol));

            var data = await _finnhubClient.SendAsync<CandleData>("stock/candle", JsonDeserialiser.Default,
                new Field(FieldKeys.Symbol, symbol),
                new Field(FieldKeys.Resolution, resolution.GetFieldValue()),
                new Field(FieldKeys.From, new DateTimeOffset(from).ToUnixTimeSeconds().ToString()),
                new Field(FieldKeys.To, new DateTimeOffset(to).ToUnixTimeSeconds().ToString()));

            return data.Map();
        }
    }
}
