using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

using MVCAPP1.Models;

namespace MVCAPP1.Controllers
{
    public class RegistradoController : Controller
    {
        string Baseurl = "http://localhost:39393/";

        public async Task<ActionResult> Index()
        {
            var ListRegistrados = new List<Registrado>();

            //Llenar la lista
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Registrados/");

                if(Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;

                    ListRegistrados = JsonConvert.DeserializeObject<List<Registrado>>(Response);

                }

            }

            return View(ListRegistrados);
        }

        public async Task<ActionResult> Details(int IdRegistrado)
        {
            var registrado = new Registrado();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();


                HttpResponseMessage Res = await client.GetAsync("api/Registrados/object1/" + IdRegistrado);

                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;

                    registrado = JsonConvert.DeserializeObject<Registrado>(Response);
                }

            }


           return View(registrado);
        }

        public async Task<ActionResult> Edit(int IdRegistrado)
        {
            var registrado = new Registrado();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();


                HttpResponseMessage Res = await client.GetAsync("api/Registrados/object1/" + IdRegistrado);

                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;

                    registrado = JsonConvert.DeserializeObject<Registrado>(Response);
                }

            }

            return View(registrado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind("Id,Title,ReleaseDate,Genre,Price,Rating")]
        public ActionResult Edit(Registrado collection)
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

                    HttpResponseMessage Res = client.PutAsync("api/Registrados/UpdateObject", content).GetAwaiter().GetResult();
                    if (Res.IsSuccessStatusCode)
                    {
                        var empResponse = Res.Content.ReadAsStringAsync().Result;
                    }


                }


               return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return View();
            }

        }

        //public async Task<ActionResult> Delete(int? IdRegistrado)
        //{
        //    var registrado = new Registrado();

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(Baseurl);
        //        client.DefaultRequestHeaders.Clear();


        //        HttpResponseMessage Res = await client.GetAsync("api/Registrados/object1/" + IdRegistrado);

        //        if (Res.IsSuccessStatusCode)
        //        {
        //            var Response = Res.Content.ReadAsStringAsync().Result;

        //            registrado = JsonConvert.DeserializeObject<Registrado>(Response);
        //        }

        //    }

        //    return View(registrado);
        //}



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int IdRegistrado)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();


                    HttpResponseMessage Res = await client.DeleteAsync("api/Registrados/DeleteParam/" + IdRegistrado);

                    if (Res.IsSuccessStatusCode)
                    {
                        var Response = Res.Content.ReadAsStringAsync().Result;

                    }

                }

                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
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
        //[Bind("Id,Title,ReleaseDate,Genre,Price,Rating")]
        public ActionResult Create(Registrado collection)
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

                    HttpResponseMessage Res = client.PostAsync("api/Registrados", content).GetAwaiter().GetResult();
                    if (Res.IsSuccessStatusCode)
                    {
                        var empResponse = Res.Content.ReadAsStringAsync().Result;
                    }


                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }

        }

    }
}
