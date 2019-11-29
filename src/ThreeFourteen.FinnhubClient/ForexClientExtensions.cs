using System;
using System.Threading.Tasks;
using ThreeFourteen.FinnhubClient.Model;
using ThreeFourteen.FinnhubClient.Serialisation;

namespace ThreeFourteen.FinnhubClient
{
    public static class ForexClientExtensions
    {
        public static Task<string[]> GetExchanges(this ForexClient client)
        {
            return client.FinnhubClient.SendAsync<string[]>("forex/exchange", JsonDeserialiser.Default);
        }

        public static Task<Symbol[]> GetSymbols(this ForexClient client, string exchange)
        {
            return client.FinnhubClient.SendAsync<Symbol[]>("forex/symbol", JsonDeserialiser.Default,
                new Field("exchange", exchange));
        }

        public static async Task<Candle[]> GetCandles(this ForexClient client, string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException(nameof(symbol));

            var data = await client.FinnhubClient.SendAsync<CandleData>("forex/candle", JsonDeserialiser.Default,
                new Field(FieldKeys.Symbol, symbol),
                new Field(FieldKeys.Resolution, "D"),
                new Field("count", "10"));

            return data.Map();
        }
    }
}
