namespace ThreeFourteen.FinnhubClient
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
