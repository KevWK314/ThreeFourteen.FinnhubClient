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
        public async Task Candles_WithCount()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadStock("candle"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var candles = await client.Stock.GetCandles("AAPL", Resolution.FiveMinutes, 3);

            candles.Should().NotBeNull();
            candles.Should().HaveCount(3);
            candles[0].Open.Should().Be(221.03m);

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1/stock/candle?token=APIKey&symbol=AAPL&resolution=5&count=3");
        }

        [Fact]
        public async Task Candles_WithRange()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadStock("candle"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var candles = await client.Stock.GetCandles("AAPL", Resolution.FiveMinutes, DateTime.Parse("2019/12/1"), DateTime.Parse("2019/12/2"));

            candles.Should().NotBeNull();
            candles.Should().HaveCount(3);
            candles[0].Volume.Should().Be(33463820);

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1/stock/candle?token=APIKey&symbol=AAPL&resolution=5&from=1575158400&to=1575244800");
        }
    }
}
