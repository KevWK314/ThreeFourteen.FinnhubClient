using System;

namespace ThreeFourteen.Finnhub.Client.Model
{
    public static class NewsCategoryExtensions
    {
        public static string GetFieldValue(this NewsCategory resolution)
        {
            switch (resolution)
            {
                case NewsCategory.General: return "general";
                case NewsCategory.Forex: return "forex";
                case NewsCategory.Crypto: return "crypto";
                case NewsCategory.Merger: return "merger";
            }
            throw new InvalidOperationException("Not a valid news category");
        }
    }
}
