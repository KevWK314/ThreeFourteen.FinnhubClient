using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ThreeFourteen.Finnhub.Client.Model;
using ThreeFourteen.Finnhub.Client.Tests.Tools;
using Xunit;

namespace ThreeFourteen.Finnhub.Client.Tests
{
    public class AlternativeData
    {
        [Fact]
        public async Task GetNews_WhenCategory()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadAlternativeData("news"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var news = await client.AlternativeData.GetNews(NewsCategory.Forex);

            news.Should().HaveCount(3);
            news[0].Category.Should().Be("technology");
            // TBD datetime
            news[0].Headline.Should().Be("Facebook acknowledges flaw in Messenger Kids app");
            news[0].Id.Should().Be(25040);
            news[0].Image.Should().Be("https://s3.reutersmedia.net/resources/r/?m=02\u0026d=20190829\u0026t=2\u0026i=1423882334\u0026w=1200\u0026r=LYNXNPEF7S07O");
            news[0].Source.Should().Be("Reuters");
            news[0].Summary.Should().Be("Facebook Inc  acknowledged a flaw in its Messenger Kids app, weeks after two U.S. senators raised privacy concerns about the application, and said that it spoke to the U.S. Federal Trade Commission about the matter.");
            news[0].Url.Should().Be("https://www.reuters.com/article/us-facebook-privacy/facebook-acknowledges-flaw-in-messenger-kids-app-idUSKCN1VJ08X");

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1/news?token=APIKey&category=forex");
        }

        [Fact]
        public async Task GetNews_WhenCategoryAndMinId()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadAlternativeData("news"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var news = await client.AlternativeData.GetNews(NewsCategory.Merger, 1212);

            news.Should().HaveCount(3);
            news[2].Category.Should().Be("company news");
            // TBD datetime
            news[2].Headline.Should().Be("GLOBAL MARKETS-Bonds reign supreme, equities struggle on recession, Brexit fears");
            news[2].Id.Should().Be(24876);
            news[2].Image.Should().Be("https://s4.reutersmedia.net/resources_v2/images/rcom-default.png");
            news[2].Source.Should().Be("Reuters");
            news[2].Summary.Should().Be("* Yields on U.S. 30-year bonds, 10-year German bunds at\nrecord low");
            news[2].Url.Should().Be("https://www.reuters.com/article/global-markets/global-markets-bonds-reign-supreme-equities-struggle-on-recession-brexit-fears-idUSL3N25P0YC");

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1/news?token=APIKey&category=merger&minId=1212");
        }

        [Fact]
        public async Task GetCompanyNews()
        {
            var httpClientTester = new HttpClientTester()
                .SetResponseContent(DataLoader.LoadAlternativeData("news"));

            var client = new FinnhubClient(httpClientTester.Client, "APIKey");

            var news = await client.AlternativeData.GetCompanyNews("AAPL");

            news.Should().HaveCount(3);
            news[0].Category.Should().Be("technology");

            httpClientTester.RequestMessage.RequestUri
                .AbsoluteUri.Should().Be("https://finnhub.io/api/v1/news/AAPL?token=APIKey");
        }
    }
}
