namespace ThreeFourteen.Finnhub.Client
{
    public class StockClient
    {
        public StockClient(FinnhubClient finnhubClient)
        {
            FinnhubClient = finnhubClient;
        }

        internal FinnhubClient FinnhubClient { get; }
    }
}
