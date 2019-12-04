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
    }
}
