namespace ThreeFourteen.FinnhubClient
{
    public class ForexClient
    {
        public ForexClient(FinnhubClient finnhubClient)
        {
            FinnhubClient = finnhubClient;
        }

        internal FinnhubClient FinnhubClient { get; }
    }
}
