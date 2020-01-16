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
            AlternativeData = new AlternativeDataClient(this);
        }

        public StockClient Stock { get; }

        public ForexClient Forex { get; }

        public CryptoClient Crypto { get; }

        public TechnicalAnalysisClient TechnicalAnalysis { get; }

        public AlternativeDataClient AlternativeData { get; }

        public void ConfigureClient(Action<FinnhubConfig> configure)
        {
            configure?.Invoke(_config);
        }

        public Task<string> GetRawDataAsync(string operation, params Field[] fields)
        {
            return SendAsync(operation, fields, content => content.ReadAsStringAsync());
        }

        internal Task<T> SendAsync<T>(string operation, IDeserialiser deserialiser, params Field[] fields)
        {
            return SendAsync(operation, fields, deserialiser.Deserialize<T>);
        }

        private async Task<T> SendAsync<T>(string operation, Field[] fields, Func<HttpContent, Task<T>> deserialise)
        {
            var parameters = CreateParameters(fields);

            var uri = new Uri(_config.BaseUri, $"/api/v1/{operation}?{parameters}");

            using (var responseMessage = await _httpClient.GetAsync(uri).ConfigureAwait(false))
            {
                if (!responseMessage.IsSuccessStatusCode)
                    throw new FinnhubException((int)responseMessage.StatusCode, responseMessage.ReasonPhrase);

                return await deserialise(responseMessage.Content).ConfigureAwait(false);
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
