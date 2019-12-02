using System;

namespace ThreeFourteen.FinnhubClient.Model
{
    public static class ResolutionExtensions
    {
        public static string GetFieldValue(this Resolution resolution)
        {
            switch (resolution)
            {
                case Resolution.OneMinute: return "1";
                case Resolution.FiveMinutes: return "5";
                case Resolution.FifteenMinutes: return "15";
                case Resolution.ThirtyMinutes: return "30";
                case Resolution.OneHour: return "60";
                case Resolution.Day: return "D";
                case Resolution.Week: return "W";
                case Resolution.Month: return "M";
            }
            throw new InvalidOperationException("Not a valid resolution");
        }
    }
}
