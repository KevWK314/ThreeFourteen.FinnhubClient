using FluentAssertions;
using System;
using System.Threading.Tasks;
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

            httpClientTester.RequestMessage.RequestUri.AbsoluteUri.Should().Be("");
        }
    }
}
