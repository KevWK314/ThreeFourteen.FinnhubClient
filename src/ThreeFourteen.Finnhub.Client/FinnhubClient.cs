using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ThreeFourteen.Finnhub.Client.Serialisation;

namespace ThreeFourteen.Finnhub.Client
{
    public class FinnhubClient
    {
        private readonly HttpClient _httpClient;
        private readonly FinnhubConfig _config = new FinnhubConfig();

        public FinnhubClient()
        {
        }

        public FinnhubClient(string apiKey)
            : this(new HttpClient(), apiKey)
        {
        }

        public FinnhubClient(HttpClient httpClient, string apiKey)
        {
            if (httpClient.BaseAddress != null) throw new ArgumentException("BaseAddress must be empty", nameof(httpClient));
            if (string.IsNullOrWhiteSpace(apiKey)) throw new ArgumentException(nameof(apiKey));

            _httpClient = httpClient;
            _config.ApiKey = apiKey;

            Stock = new StockClient(this);
            Forex = new ForexClient(this);
            Crypto = new CryptoClient(this);
            TechnicalAnalysis = new TechnicalAnalysisClient(this);
        }

        public StockClient Stock { get; }

        public ForexClient Forex { get; }

        public CryptoClient Crypto { get; }

        public TechnicalAnalysisClient TechnicalAnalysis { get; }

        public void ConfigureClient(Action<FinnhubConfig> configure)
        {
            configure?.Invoke(_config);
        }

        internal async Task<T> SendAsync<T>(string operation, IDeserialiser deserialiser, params Field[] fields)
        {
            var parameters = CreateParameters(fields);

            var uri = new Uri(_config.BaseUri, $"/api/v1/{operation}?{parameters}");

            using (var responseMessage = await _httpClient.GetAsync(uri))
            {
                if (!responseMessage.IsSuccessStatusCode)
                    throw new FinnhubException((int)responseMessage.StatusCode, responseMessage.ReasonPhrase);

                return await deserialiser.Deserialize<T>(responseMessage.Content);
            }
        }

        private string CreateParameters(Field[] fields)
        {
            if (string.IsNullOrEmpty(_config.ApiKey)) throw new InvalidOperationException("ApiKey not set");

            var parameters = string.Join("&", fields.Select(f => $"{f.Key}={WebUtility.UrlEncode(f.Value)}"));
            parameters = string.IsNullOrEmpty(parameters) ?
                string.Empty : "&" + parameters;

            return $"token={_config.ApiKey}{parameters}";
        }
    }
}
