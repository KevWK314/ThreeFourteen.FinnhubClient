using System;

namespace ThreeFourteen.FinnhubClient
{
    public class FinnhubException : Exception
    {
        public FinnhubException(int statusCode, string reasonPhrase)
        {
            StatusCode = statusCode;
            ReasonPhrase = reasonPhrase;
        }

        public int StatusCode { get; }
        public string ReasonPhrase { get; }
    }
}
