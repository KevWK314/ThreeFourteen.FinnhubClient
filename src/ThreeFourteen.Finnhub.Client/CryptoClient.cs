namespace ThreeFourteen.Finnhub.Client
{
    public class CryptoClient
    {
        public CryptoClient(FinnhubClient finnhubClient)
        {
            FinnhubClient = finnhubClient;
        }

        internal FinnhubClient FinnhubClient { get; }
    }
}
