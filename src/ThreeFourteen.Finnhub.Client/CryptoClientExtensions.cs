using System;
using System.Threading.Tasks;
using ThreeFourteen.Finnhub.Client.Model;
using ThreeFourteen.Finnhub.Client.Serialisation;

namespace ThreeFourteen.Finnhub.Client
{
    public static class CryptoClientExtensions
    {
        public static Task<string[]> GetExchanges(this CryptoClient client)
        {
            return client.FinnhubClient.SendAsync<string[]>("crypto/exchange", JsonDeserialiser.Default);
        }

        public static Task<Symbol[]> GetSymbols(this CryptoClient client, string exchange)
        {
            return client.FinnhubClient.SendAsync<Symbol[]>("crypto/symbol", JsonDeserialiser.Default,
                new Field("exchange", exchange));
        }

        public static async Task<Candle[]> GetCandles(this CryptoClient client, string symbol, Resolution resolution, int count)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException(nameof(symbol));

            var data = await client.FinnhubClient.SendAsync<CandleData>("crypto/candle", JsonDeserialiser.Default,
                new Field(FieldKeys.Symbol, symbol),
                new Field(FieldKeys.Resolution, resolution.GetFieldValue()),
                new Field(FieldKeys.Count, count.ToString()));

            return data.Map();
        }

        public static Task<Candle[]> GetCandles(this CryptoClient client, string symbol, Resolution resolution, DateTime from)
        {
            return GetCandles(client, symbol, resolution, from, DateTime.UtcNow);
        }

        public static async Task<Candle[]> GetCandles(this CryptoClient client, string symbol, Resolution resolution, DateTime from, DateTime to)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException(nameof(symbol));

            var data = await client.FinnhubClient.SendAsync<CandleData>("crypto/candle", JsonDeserialiser.Default,
                new Field(FieldKeys.Symbol, symbol),
                new Field(FieldKeys.Resolution, resolution.GetFieldValue()),
                new Field(FieldKeys.From, new DateTimeOffset(from).ToUnixTimeSeconds().ToString()),
                new Field(FieldKeys.To, new DateTimeOffset(to).ToUnixTimeSeconds().ToString()));

            return data.Map();
        }
    }
}
