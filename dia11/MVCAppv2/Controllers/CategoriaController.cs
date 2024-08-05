using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;

using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;

using Newtonsoft.Json;

using MVCAppv2.Models;

namespace MVCAppv2.Controllers
{
    public class CategoriaController : Controller
    {
        string BaseURL = "http://localhost:5244/";

        public async Task<ActionResult> Index()
        {
            //defino la lista
            var ListCategorias = new List<Categoria>();

            //llenar esta lista
            using (var client = new HttpClient())
            {
                //call api backend

                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/Categorias");


                if(res.IsSuccessStatusCode)
                {
                    var Response = res.Content.ReadAsStringAsync().Result;

                    ListCategorias = JsonConvert.DeserializeObject<List<Categoria>>(Response);
                }

            }

            return View(ListCategorias);
        }

        public async Task<ActionResult> Details(int IdCategoria)
        {

            var categoria = new Categoria();
			
            using (var client = new HttpClient())
            {
				client.BaseAddress = new Uri(BaseURL);
				client.DefaultRequestHeaders.Clear();

				HttpResponseMessage res = await client.GetAsync("api/Categorias/id/" + IdCategoria);

                if (res.IsSuccessStatusCode)
                {
                    var Response = res.Content.ReadAsStringAsync().Result;

                    categoria = JsonConvert.DeserializeObject<Categoria>(Response);
                }

		    }

		    return View(categoria);
        }

	}
}
