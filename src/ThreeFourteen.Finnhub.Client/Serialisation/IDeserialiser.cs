using System.Net.Http;
using System.Threading.Tasks;

namespace ThreeFourteen.Finnhub.Client.Serialisation
{
    public interface IDeserialiser
    {
        Task<TResponse> Deserialize<TResponse>(HttpContent responseContent);
    }
}