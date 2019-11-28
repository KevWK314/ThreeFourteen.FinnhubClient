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
            /// forex / symbol ? exchange = oanda
            return client.FinnhubClient.SendAsync<Symbol[]>("crypto/symbol", JsonDeserialiser.Default,
                new Field("exchange", exchange));
        }
    }
}
