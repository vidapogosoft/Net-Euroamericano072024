using System.Threading.Tasks;

namespace BlazorApp1.Repositorio
{
	public interface IRepositorio
	{

		Task<HttpResponseWrapper<T>> GetRepositorio<T>(string url);

	}
}
