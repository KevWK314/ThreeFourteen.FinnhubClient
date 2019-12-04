using System;
using System.Collections.Generic;
using System.Linq;

namespace ThreeFourteen.Finnhub.Client.Model
{
    public static class CandleDataExtensions
    {
        private const string NoData = "no_data";
        public static Candle[] Map(this CandleData candleData)
        {
            try
            {
                if ((candleData?.Status ?? NoData) == NoData)
                    return new Candle[0];

                return MapInternal(candleData).ToArray();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to Map Candle Data", ex);
            }
        }

        private static IEnumerable<Candle> MapInternal(CandleData candleData)
        {
            for (int i = 0; i < candleData.Close.Count; i++)
            {
                yield return new Candle
                {
                    High = candleData.High[i],
                    Low = candleData.Low[i],
                    Open = candleData.Open[i],
                    Close = candleData.Close[i],
                    Volume = candleData.Volume?[i] ?? 0,
                    Timestamp = DateTimeOffset.FromUnixTimeSeconds(candleData.Timestamp[i]).UtcDateTime
                };
            }
        }
    }
}
