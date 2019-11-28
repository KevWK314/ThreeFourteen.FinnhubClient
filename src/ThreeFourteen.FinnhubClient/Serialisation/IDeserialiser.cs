using System.Net.Http;
using System.Threading.Tasks;

namespace ThreeFourteen.FinnhubClient.Serialisation
{
    public interface IDeserialiser
    {
        Task<TResponse> Deserialize<TResponse>(HttpContent responseContent);
    }
}