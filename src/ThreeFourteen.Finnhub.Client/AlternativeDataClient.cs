using System;
using System.Threading.Tasks;
using ThreeFourteen.Finnhub.Client.Model;
using ThreeFourteen.Finnhub.Client.Serialisation;

namespace ThreeFourteen.Finnhub.Client
{
    public class AlternativeDataClient
    {
        private readonly FinnhubClient _finnhubClient;

        internal AlternativeDataClient(FinnhubClient finnhubClient)
        {
            _finnhubClient = finnhubClient;
        }

        public Task<NewsEntry[]> GetNews(NewsCategory category)
        {
            return _finnhubClient.SendAsync<NewsEntry[]>("news", JsonDeserialiser.Default,
                new Field(FieldKeys.Category, category.GetFieldValue()));
        }

        public Task<NewsEntry[]> GetNews(NewsCategory category, int minId)
        {
            if (minId < 0) throw new ArgumentException(nameof(minId));

            return _finnhubClient.SendAsync<NewsEntry[]>("news", JsonDeserialiser.Default,
                new Field(FieldKeys.Category, category.GetFieldValue()),
                new Field(FieldKeys.MinId, minId.ToString()));
        }

        public Task<NewsEntry[]> GetCompanyNews(string symbol)
        {
            if (string.IsNullOrEmpty(symbol)) throw new ArgumentException(nameof(symbol));

            return _finnhubClient.SendAsync<NewsEntry[]>($"news/{symbol}", JsonDeserialiser.Default);
        }

        public Task<NewsSentiment> GetNewsSentiment(string symbol)
        {
            if (string.IsNullOrEmpty(symbol)) throw new ArgumentException(nameof(symbol));

            return _finnhubClient.SendAsync<NewsSentiment>($"news-sentiment", JsonDeserialiser.Default,
                new Field(FieldKeys.Symbol, symbol));
        }
    }
}
