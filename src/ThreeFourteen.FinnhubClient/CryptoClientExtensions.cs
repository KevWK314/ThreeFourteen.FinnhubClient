using System;
using System.Threading.Tasks;
using ThreeFourteen.FinnhubClient.Model;
using ThreeFourteen.FinnhubClient.Serialisation;

namespace ThreeFourteen.FinnhubClient
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

        public static async Task<Candle[]> GetCandles(this CryptoClient client, string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException(nameof(symbol));

            var data = await client.FinnhubClient.SendAsync<CandleData>("crypto/candle", JsonDeserialiser.Default,
                new Field(FieldKeys.Symbol, symbol),
                new Field(FieldKeys.Resolution, "D"),
                new Field("count", "10"));

            return data.Map();
        }
    }
}
