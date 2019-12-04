using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ThreeFourteen.Finnhub.Client.Tests.Tools
{
    public class HttpClientTester : HttpMessageHandler
    {
        private readonly HttpResponseMessage _responseMessage = new HttpResponseMessage(HttpStatusCode.OK);

        public HttpRequestMessage RequestMessage { get; private set; }

        public HttpClient Client { get; private set; }

        public HttpClientTester()
        {
            Client = new HttpClient(this);
        }

        public HttpClientTester SetResponseStatusCode(HttpStatusCode code)
        {
            _responseMessage.StatusCode = code;
            return this;
        }

        public HttpClientTester SetResponseContent(string content)
        {
            _responseMessage.Content = new StringContent(content);
            return this;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            RequestMessage = request;
            return await Task.FromResult(_responseMessage);
        }
    }
}
