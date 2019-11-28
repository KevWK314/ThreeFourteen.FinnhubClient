namespace ThreeFourteen.FinnhubClient
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
