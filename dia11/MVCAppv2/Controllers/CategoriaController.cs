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

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Details(Categoria delitem)
        {
			try
			{
				using (var client = new HttpClient())
				{

					client.BaseAddress = new Uri(BaseURL);
					client.DefaultRequestHeaders.Clear();
				
					HttpResponseMessage res = await client.DeleteAsync("api/Categorias/delete2/" + delitem.Idcategoria);

					if (res.IsSuccessStatusCode)
					{
						var Response = res.Content.ReadAsStringAsync().Result;
					}
				}

				return RedirectToAction("Index");

			}
			catch
			{

				return View();
			}
		}


		public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult Create(Categoria newitem)
        {
            try
            {
                newitem.Idcategoria = 0;
                newitem.Estado = true;

				using (var client = new HttpClient())
                {

					client.BaseAddress = new Uri(BaseURL);
					client.DefaultRequestHeaders.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var json = JsonConvert.SerializeObject(newitem);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

					HttpResponseMessage res = client.PostAsync("api/Categorias/registro/", content).GetAwaiter().GetResult();

                    if (res.IsSuccessStatusCode)
                    {
                        var Response = res.Content.ReadAsStringAsync().Result;
                    }

				}

				return RedirectToAction("Index");

            }
            catch
            {

                return View();
            }

        }

        public async Task<ActionResult> Edit(int IdCategoria)
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

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Categoria edititem)
        {
			try
			{
				edititem.Estado = true;

				using (var client = new HttpClient())
				{

					client.BaseAddress = new Uri(BaseURL);
					client.DefaultRequestHeaders.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					var json = JsonConvert.SerializeObject(edititem);
					var content = new StringContent(json, Encoding.UTF8, "application/json");

					HttpResponseMessage res = client.PutAsync("api/Categorias/upd1/", content).GetAwaiter().GetResult();

					if (res.IsSuccessStatusCode)
					{
						var Response = res.Content.ReadAsStringAsync().Result;
					}

				}

				return RedirectToAction("Index");

			}
			catch
			{

				return View();
			}
		}

	}
}
