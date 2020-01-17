using System;
using System.Linq;
using System.Threading.Tasks;
using ThreeFourteen.Finnhub.Client.Model;

namespace ThreeFourteen.Finnhub.Client.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            Run().GetAwaiter().GetResult();
        }

        static async Task Run()
        {
            var apiKey = Environment.GetEnvironmentVariable("FinnhubApiKey", EnvironmentVariableTarget.User);
            var client = new FinnhubClient(apiKey);

            await TryStocks(client);
            await TryForex(client);
            await TryCrypto(client);
            await TryTechnicalAnalysis(client);
            await TryAlternativeData(client);
            await TryGetRawData(client);

            Console.WriteLine();
            Console.WriteLine("Done");
            Console.ReadKey();
        }

        static async Task TryStocks(FinnhubClient client)
        {
            Console.WriteLine("Stock");

            var company = await client.Stock.GetCompany("AAPL");
            Console.WriteLine($"Success: Retrieved company {company.Name}.");

            var compensation = await client.Stock.GetCompensation("AAPL");
            Console.WriteLine($"Success: Retrieved compensation for {compensation.Name} ({compensation.CompanyName}).");

            var recommendations = await client.Stock.GetRecommendationTrends("AAPL");
            Console.WriteLine($"Success: Retrieved {recommendations.Length} recommendations.");

            var priceTarget = await client.Stock.GetPriceTarget("AAPL");
            Console.WriteLine($"Success: Retrieved price target for {priceTarget.Symbol}.");

            var peers = await client.Stock.GetPeers("AAPL");
            Console.WriteLine($"Success: Retrieved {peers.Length} peers.");

            var earnings = await client.Stock.GetEarnings("AAPL");
            Console.WriteLine($"Success: Retrieved {earnings.Length} earnings entries.");

            var exchanges = await client.Stock.GetExchanges();
            Console.WriteLine($"Success: {exchanges.Length} stock exchanges found.");

            var symbols = await client.Stock.GetSymbols("US");
            Console.WriteLine($"Success: Stock exchange has {symbols.Length} symbols.");

            var quote = await client.Stock.GetQuote("AAPL");
            Console.WriteLine($"Success: Current AAPL quote price is {quote.Current}.");

            var candles = await client.Stock.GetCandles("AAPL", Resolution.Day, 10);
            Console.WriteLine($"Success: Retrieved {candles.Length} candles.");
        }

        static async Task TryForex(FinnhubClient client)
        {
            Console.WriteLine();
            Console.WriteLine("Forex");

            var exchanges = await client.Forex.GetExchanges();
            Console.WriteLine($"Success: {exchanges.Length} forex exchanges found.");

            var symbols = await client.Forex.GetSymbols("fxcm");
            Console.WriteLine($"Success: Forex exchange has {symbols.Length} symbols.");

            var candles = await client.Forex.GetCandles(symbols.First().CandleSymbol, Resolution.Day, 10);
            Console.WriteLine($"Success: Retrieved {candles.Length} candles.");
        }

        static async Task TryCrypto(FinnhubClient client)
        {
            Console.WriteLine();
            Console.WriteLine("Crypto");

            var exchanges = await client.Crypto.GetExchanges();
            Console.WriteLine($"Success: {exchanges.Length} crypto exchanges found.");

            var symbols = await client.Crypto.GetSymbols("Binance");
            Console.WriteLine($"Success: Crypto exchange has {symbols.Length} symbols.");

            var candles = await client.Crypto.GetCandles(symbols.First().CandleSymbol, Resolution.Day, 10);
            Console.WriteLine($"Success: Retrieved {candles.Length} candles.");
        }

        static async Task TryTechnicalAnalysis(FinnhubClient client)
        {
            Console.WriteLine();
            Console.WriteLine("Technical Analysis");

            var supportResistance = await client.TechnicalAnalysis.GetSupportResistance("AAPL", Resolution.Day);
            Console.WriteLine($"Success: {supportResistance.Levels.Count} support/resistance levels.");
        }

        static async Task TryAlternativeData(FinnhubClient client)
        {
            Console.WriteLine();
            Console.WriteLine("Alternative Data");

            var news = await client.AlternativeData.GetNews(NewsCategory.Forex);
            Console.WriteLine($"Success: {news.Length} Forex news stories.");

            var appleNews = await client.AlternativeData.GetCompanyNews("AAPL");
            Console.WriteLine($"Success: {appleNews.Length} Company news stories.");

            var newsSentiment = await client.AlternativeData.GetNewsSentiment("AAPL");
            Console.WriteLine($"Success: News sentiment score is {newsSentiment.CompanyNewsScore}.");
        }

        static async Task TryGetRawData(FinnhubClient client)
        {
            Console.WriteLine();
            Console.WriteLine("Raw Data");

            var rawData = await client.GetRawDataAsync("stock/profile", new Field(FieldKeys.Symbol, "AAPL"));
            Console.WriteLine($"Success: Raw data has {rawData.Length} characters.");
        }
    }
}
