using System.Threading.Tasks;

namespace ARTiculate.Data
{
    public interface IApiClient
    {
        Task<T> GetASync<T>(string endpoint);
    }
}
