using System.IO;

namespace ThreeFourteen.Finnhub.Client.Tests.Tools
{
    public static class DataLoader
    {
        private static readonly string Root = new FileInfo(typeof(DataLoader).Assembly.Location).DirectoryName;

        public static string LoadStock(string name)
        {
            var file = Path.Combine(Root, $@"Data\Stock\{name}.json");
            if (!File.Exists(file))
                throw new FileNotFoundException($"Can't find stock data file {name}.json");

            return File.ReadAllText(file);
        }

        public static string LoadForex(string name)
        {
            var file = Path.Combine(Root, $@"Data\Forex\{name}.json");
            if (!File.Exists(file))
                throw new FileNotFoundException($"Can't find forex data file {name}.json");

            return File.ReadAllText(file);
        }

        public static string LoadCrypto(string name)
        {
            var file = Path.Combine(Root, $@"Data\Crypto\{name}.json");
            if (!File.Exists(file))
                throw new FileNotFoundException($"Can't find crypto data file {name}.json");

            return File.ReadAllText(file);
        }

        public static string LoadTechnicalAnalysis(string name)
        {
            var file = Path.Combine(Root, $@"Data\TechnicalAnalysis\{name}.json");
            if (!File.Exists(file))
                throw new FileNotFoundException($"Can't find technical analysis data file {name}.json");

            return File.ReadAllText(file);
        }
    }
}
