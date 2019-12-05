using System;

namespace ThreeFourteen.Finnhub.Client.Model
{
    public class Candle
    {
        public DateTime Timestamp { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Open { get; set; }
        public decimal Close { get; set; }
        public long Volume { get; set; }
    }
}
