using System.Text;
using System.Text.Json;

namespace BlazorApp1.Repositorio
{
	public class CategoriaRepositorio : IRepositorio
	{
		private readonly HttpClient http;

		private JsonSerializerOptions OpcionesPorDefecto => new JsonSerializerOptions()
		{ PropertyNameCaseInsensitive = true};

		public CategoriaRepositorio(HttpClient httpclient)
		{
			http = httpclient;
		}

		public async Task<HttpResponseWrapper<T>> GetRepositorio<T>(string url)
		{
			var response = await http.GetAsync(url);
			if (response.IsSuccessStatusCode)
			{
				var responsetrue = await DeserealizarRespuesta<T>(response, OpcionesPorDefecto);

				return new HttpResponseWrapper<T>(responsetrue, false, response);
			}
			else
			{
				return new HttpResponseWrapper<T>(default, true, response);
			}
		}

		private async Task<T> DeserealizarRespuesta<T>(HttpResponseMessage httresponse, JsonSerializerOptions jsonOptions)
		{
			var responsestring = await httresponse.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<T>(responsestring, jsonOptions);
		}


	}
}
