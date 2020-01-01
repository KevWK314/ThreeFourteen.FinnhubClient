using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ThreeFourteen.Finnhub.Client.Tests.Tools;
using Xunit;

namespace ThreeFourteen.Finnhub.Client.Tests
{
    public class TechnicalAnalysis
    {
        [Fact]
        public async Task SupportResistance()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadTechnicalAnalysis("supportResistance"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var supportResistance = await client.TechnicalAnalysis.GetSupportResistance("AAPL", Model.Resolution.Day);

            supportResistance.Should().NotBeNull();
            supportResistance.Levels.Count.Should().Be(6);

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1//scan/support-resistance?token=APIKey&symbol=AAPL&resolution=D");
        }
    }
}
