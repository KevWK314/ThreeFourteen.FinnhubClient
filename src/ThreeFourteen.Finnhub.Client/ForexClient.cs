using System;
using System.Threading.Tasks;
using ThreeFourteen.Finnhub.Client.Model;
using ThreeFourteen.Finnhub.Client.Serialisation;

namespace ThreeFourteen.Finnhub.Client
{
    public class ForexClient
    {
        private readonly FinnhubClient _finnhubClient;

        internal ForexClient(FinnhubClient finnhubClient)
        {
            _finnhubClient = finnhubClient;
        }

        public Task<string[]> GetExchanges()
        {
            return _finnhubClient.SendAsync<string[]>("forex/exchange", JsonDeserialiser.Default);
        }

        public Task<Symbol[]> GetSymbols(string exchange)
        {
            return _finnhubClient.SendAsync<Symbol[]>("forex/symbol", JsonDeserialiser.Default,
                new Field(FieldKeys.Exchange, exchange));
        }

        public async Task<Candle[]> GetCandles(string symbol, Resolution resolution, int count)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException(nameof(symbol));

            var data = await _finnhubClient.SendAsync<CandleData>("forex/candle", JsonDeserialiser.Default,
                new Field(FieldKeys.Symbol, symbol),
                new Field(FieldKeys.Resolution, resolution.GetFieldValue()),
                new Field(FieldKeys.Count, count.ToString()))
                .ConfigureAwait(false);

            return data.Map();
        }

        public Task<Candle[]> GetCandles(string symbol, Resolution resolution, DateTime from)
        {
            return GetCandles(symbol, resolution, from, DateTime.UtcNow);
        }

        public async Task<Candle[]> GetCandles(string symbol, Resolution resolution, DateTime from, DateTime to)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException(nameof(symbol));

            var data = await _finnhubClient.SendAsync<CandleData>("forex/candle", JsonDeserialiser.Default,
                new Field(FieldKeys.Symbol, symbol),
                new Field(FieldKeys.Resolution, resolution.GetFieldValue()),
                new Field(FieldKeys.From, new DateTimeOffset(from).ToUnixTimeSeconds().ToString()),
                new Field(FieldKeys.To, new DateTimeOffset(to).ToUnixTimeSeconds().ToString()))
                .ConfigureAwait(false);

            return data.Map();
        }
    }
}
