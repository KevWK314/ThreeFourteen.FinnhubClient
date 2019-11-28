using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace ThreeFourteen.FinnhubClient.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var apiKey = Environment.GetEnvironmentVariable("FinnhubApiKey", EnvironmentVariableTarget.User);
            var client = new FinnhubClient(apiKey);

            //TryStocks(client).Wait();
            //TryForex(client).Wait();
            TryCrypto(client).Wait();

            Console.ReadKey();
        }

        static async Task TryForex(FinnhubClient client)
        {
            var exchanges = await client.Forex.GetExchanges();
            Console.WriteLine($"Success: {exchanges.Length} forex exchanges found.");

            var symbols = await client.Forex.GetSymbols("fxcm");
            Console.WriteLine($"Success: Forex exchange has {symbols.Length} symbols.");
        }

        static async Task TryCrypto(FinnhubClient client)
        {
            var exchanges = await client.Crypto.GetExchanges();
            Console.WriteLine($"Success: {exchanges.Length} crypto exchanges found.");

            var symbols = await client.Crypto.GetSymbols("fxcm");
            Console.WriteLine($"Success: Crypto exchange has {symbols.Length} symbols.");
        }

        static async Task TryStocks(FinnhubClient client)
        {
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
        }
    }
}
