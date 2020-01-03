using FluentAssertions;
using System;
using System.Threading.Tasks;
using ThreeFourteen.Finnhub.Client.Model;
using ThreeFourteen.Finnhub.Client.Tests.Tools;
using Xunit;

namespace ThreeFourteen.Finnhub.Client.Tests
{
    public class Crypto
    {
        [Fact]
        public async Task Exchanges()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadCrypto("exchanges"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var exchanges = await client.Crypto.GetExchanges();

            exchanges.Should().NotBeNull();
            exchanges.Should().HaveCount(12);
            exchanges[11].Should().Be("HUOBI");

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1/crypto/exchange?token=APIKey");
        }

        [Fact]
        public async Task Symbols()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadCrypto("symbols"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var exchanges = await client.Crypto.GetSymbols("binance");

            exchanges.Should().NotBeNull();
            exchanges.Should().HaveCount(3);
            exchanges[2].Description.Should().Be("Binance BNBBTC");
            exchanges[2].DisplaySymbol.Should().Be("BNB/BTC");
            exchanges[2].CandleSymbol.Should().Be("BINANCE:BNBBTC");

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1/crypto/symbol?token=APIKey&exchange=binance");
        }

        [Fact]
        public async Task Candles_WithCount()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadCrypto("candles"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var candles = await client.Crypto.GetCandles("BINANCE:BTCUSDT", Resolution.Month, 4);

            candles.Should().NotBeNull();
            candles.Should().HaveCount(4);
            candles[3].Low.Should().Be(1.10101m);

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1/crypto/candle?token=APIKey&symbol=BINANCE%3ABTCUSDT&resolution=M&count=4");
        }

        [Fact]
        public async Task Candles_WithRange()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadCrypto("candles"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var candles = await client.Crypto.GetCandles("BINANCE:BTCUSDT", Resolution.Month, DateTime.Parse("2019/12/1"), DateTime.Parse("2019/12/2"));

            candles.Should().NotBeNull();
            candles.Should().HaveCount(4);
            candles[3].Low.Should().Be(1.10101m);

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1/crypto/candle?token=APIKey&symbol=BINANCE%3ABTCUSDT&resolution=M&from=1575158400&to=1575244800");
        }
    }
}
