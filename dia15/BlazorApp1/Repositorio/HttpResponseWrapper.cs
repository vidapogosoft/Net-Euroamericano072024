using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp1.Repositorio
{
	public class HttpResponseWrapper<T>
	{
		public bool Error { get; set; }
		public T Response { get; set; }
		public HttpResponseMessage HttpResponse { get; set; }

		public HttpResponseWrapper(T response, bool error, HttpResponseMessage httpresponse)
		{
			Error = error;
			Response = response;
			HttpResponse = httpresponse;
		}

		public async Task<string> GetBody()
		{
			return await HttpResponse.Content.ReadAsStringAsync();
		}

	}
}
