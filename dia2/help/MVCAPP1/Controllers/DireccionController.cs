using Microsoft.AspNetCore.Mvc;
using MVCAPP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace MVCAPP1.Controllers
{
    public class DireccionController : Controller
    {
        string Baseurl = "http://localhost:39393/";

        public ActionResult Index(Registrado model)
        {
            return View(model);
        }

        public ActionResult Create(string Idregistrado)
        {
            ViewBag.id = Idregistrado;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Direcciones collection)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var json = JsonConvert.SerializeObject(collection);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage Res = client.PostAsync("api/Registrados/Direcciones2", content).GetAwaiter().GetResult();

                    if (Res.IsSuccessStatusCode)
                    {
                        var RegResponse = Res.Content.ReadAsStringAsync().Result;
                    }

                }

                return RedirectToAction("Index", "Registrado");

            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
