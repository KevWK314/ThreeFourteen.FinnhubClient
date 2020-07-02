using FluentAssertions;
using System;
using System.Threading.Tasks;
using ThreeFourteen.Finnhub.Client.Model;
using ThreeFourteen.Finnhub.Client.Tests.Tools;
using Xunit;

namespace ThreeFourteen.Finnhub.Client.Tests
{
    public class Stocks
    {
        [Fact]
        public async Task Company()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadStock("company"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var company = await client.Stock.GetCompany("AAPL");

            company.Should().NotBeNull();
            company.Address.Should().Be("One Apple Park Way");

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1/stock/profile?token=APIKey&symbol=AAPL");
        }

        [Fact]
        public async Task CompanyByIsin()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadStock("company"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var company = await client.Stock.GetCompanyByIsin("US0378331005");

            company.Should().NotBeNull();
            company.Address.Should().Be("One Apple Park Way");

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1/stock/profile?token=APIKey&isin=US0378331005");
        }

        [Fact]
        public async Task CompanyByCusip()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadStock("company"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var company = await client.Stock.GetCompanyByCusip("037833100");

            company.Should().NotBeNull();
            company.Address.Should().Be("One Apple Park Way");

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1/stock/profile?token=APIKey&cusip=037833100");
        }

        [Fact]
        public async Task Compensation()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadStock("compensation"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var compensation = await client.Stock.GetCompensation("AAPL");

            compensation.Should().NotBeNull();
            compensation.Total.Should().Be(103211163);

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1/stock/ceo-compensation?token=APIKey&symbol=AAPL");
        }

        [Fact]
        public async Task PriceTarget()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadStock("priceTarget"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var priceTarget = await client.Stock.GetPriceTarget("AAPL");

            priceTarget.Should().NotBeNull();
            priceTarget.TargetMedian.Should().Be(417.5);

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1/stock/price-target?token=APIKey&symbol=AAPL");
        }

        [Fact]
        public async Task RecommendationTrends()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadStock("recommendationTrends"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var recommendationTrends = await client.Stock.GetRecommendationTrends("AAPL");

            recommendationTrends.Should().NotBeNull();
            recommendationTrends.Should().HaveCount(4);
            recommendationTrends[0].StrongBuy.Should().Be(11);

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1/stock/recommendation?token=APIKey&symbol=AAPL");
        }

        [Fact]
        public async Task Peers()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadStock("peers"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var peers = await client.Stock.GetPeers("NFLX");

            peers.Should().NotBeNull();
            peers.Should().HaveCount(10);
            peers[0].Should().Be("AAPL");

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1/stock/peers?token=APIKey&symbol=NFLX");
        }

        [Fact]
        public async Task Earnings()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadStock("earnings"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var earnings = await client.Stock.GetEarnings("AAPL");

            earnings.Should().NotBeNull();
            earnings.Should().HaveCount(4);
            earnings[0].Actual.Should().Be(2.46m);

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1/stock/earnings?token=APIKey&symbol=AAPL");
        }

        [Fact]
        public async Task Exchanges()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadStock("exchanges"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var exchanges = await client.Stock.GetExchanges();

            exchanges.Should().NotBeNull();
            exchanges.Should().HaveCount(3);
            exchanges[0].Code.Should().Be("US");
            exchanges[0].Name.Should().Be("US exchanges");

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1/stock/exchange?token=APIKey");
        }

        [Fact]
        public async Task Symbols()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadStock("symbols"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var symbols = await client.Stock.GetSymbols("US");

            symbols.Should().NotBeNull();
            symbols.Should().HaveCount(3);
            symbols[2].Description.Should().Be("PERTH MINT PHYSICAL GOLD ETF");
            symbols[2].DisplaySymbol.Should().Be("AAAU");
            symbols[2].CandleSymbol.Should().Be("AAAU");

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1/stock/symbol?token=APIKey&exchange=US");
        }

        [Fact]
        public async Task Quote()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadStock("quote"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var quote = await client.Stock.GetQuote("AAPL");

            quote.Should().NotBeNull();
            quote.Current.Should().Be(261.74m);
            quote.High.Should().Be(263.31m);
            quote.Low.Should().Be(260.68m);
            quote.Open.Should().Be(261.07m);
            quote.PreviousClose.Should().Be(259.45m);

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1/quote?token=APIKey&symbol=AAPL");
        }

        [Fact]
        public async Task Candles_WithCount()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadStock("candles"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var candles = await client.Stock.GetCandles("AAPL", Resolution.FiveMinutes, 3);

            candles.Should().NotBeNull();
            candles.Should().HaveCount(3);
            candles[0].High.Should().Be(222.49m);
            candles[0].Low.Should().Be(217.19m);
            candles[0].Open.Should().Be(221.03m);
            candles[0].Close.Should().Be(217.68m);
            candles[0].Volume.Should().Be(33463820);
            candles[0].Timestamp.Should().Be(DateTime.Parse("2019-09-24 04:00:00"));

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1/stock/candle?token=APIKey&symbol=AAPL&resolution=5&count=3");
        }

        [Fact]
        public async Task Candles_WithRange()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadStock("candles"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var candles = await client.Stock.GetCandles("AAPL", Resolution.FiveMinutes, new DateTimeOffset(2019, 12, 1, 0, 0, 0, TimeSpan.Zero).UtcDateTime, new DateTimeOffset(2019, 12, 2, 0, 0, 0, TimeSpan.Zero).UtcDateTime);

            candles.Should().NotBeNull();
            candles.Should().HaveCount(3);
            candles[2].High.Should().Be(220.94m);
            candles[2].Low.Should().Be(218.83m);
            candles[2].Open.Should().Be(220m);
            candles[2].Close.Should().Be(219.89m);
            candles[2].Volume.Should().Be(20730608);
            candles[2].Timestamp.Should().Be(DateTime.Parse("2019-09-26 04:00:00"));

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1/stock/candle?token=APIKey&symbol=AAPL&resolution=5&from=1575158400&to=1575244800");
        }
    }
}
