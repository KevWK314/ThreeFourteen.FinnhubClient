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
            /// forex / symbol ? exchange = oanda
            return client.FinnhubClient.SendAsync<Symbol[]>("forex/symbol", JsonDeserialiser.Default,
                new Field("exchange", exchange));
        }
    }
}
