using System;

namespace ThreeFourteen.Finnhub.Client.Model
{
    public class Candle
    {
        public DateTime Timestamp { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
        public int Volume { get; set; }
    }
}
