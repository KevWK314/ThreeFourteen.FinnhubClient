using FluentAssertions;
using System;
using System.Threading.Tasks;
using ThreeFourteen.Finnhub.Client.Model;
using ThreeFourteen.Finnhub.Client.Tests.Tools;
using Xunit;

namespace ThreeFourteen.Finnhub.Client.Tests
{
    public class Forex
    {
        [Fact]
        public async Task Exchanges()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadForex("exchanges"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var exchanges = await client.Forex.GetExchanges();

            exchanges.Should().NotBeNull();
            exchanges.Should().HaveCount(5);
            exchanges[0].Should().Be("oanda");

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1/forex/exchange?token=APIKey");
        }

        [Fact]
        public async Task Symbols()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadForex("symbols"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var exchanges = await client.Forex.GetSymbols("ic markets");

            exchanges.Should().NotBeNull();
            exchanges.Should().HaveCount(3);
            exchanges[0].Description.Should().Be("IC MARKETS Euro vs US Dollar EURUSD");

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1/forex/symbol?token=APIKey&exchange=ic+markets");
        }

        [Fact]
        public async Task Candles_WithCount()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadForex("candles"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var candles = await client.Forex.GetCandles("OANDA:EUR_USD", Resolution.Day, 4);

            candles.Should().NotBeNull();
            candles.Should().HaveCount(4);
            candles[0].Open.Should().Be(1.0996m);

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1/forex/candle?token=APIKey&symbol=OANDA%3AEUR_USD&resolution=D&count=4");
        }

        [Fact]
        public async Task Candles_WithRange()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadForex("candles"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var candles = await client.Forex.GetCandles("OANDA:EUR_USD", Resolution.Day, DateTime.Parse("2019/12/1"), DateTime.Parse("2019/12/2"));

            candles.Should().NotBeNull();
            candles.Should().HaveCount(4);
            candles[0].Volume.Should().Be(75789);

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1/forex/candle?token=APIKey&symbol=OANDA%3AEUR_USD&resolution=D&from=1575158400&to=1575244800");
        }
    }
}
