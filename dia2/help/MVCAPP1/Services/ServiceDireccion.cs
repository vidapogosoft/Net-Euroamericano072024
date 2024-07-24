using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Net.Http;
using MVCAPP1.Models;
using System.Collections.Generic;
using System;

namespace MVCAPP1.Services
{
    
    public class ServiceDireccion
    {
        //la implementacion del HTT Get

        List<Direcciones> direccion;
        HttpClient _Client;

        public ServiceDireccion()
        {
            _Client = new HttpClient();
        }

        public async Task<List<Direcciones>> GetDireccionesByIdRegistrado(string IdRegistrado)
        {
            var uriget = new Uri("http://localhost:39393/api/Registrados/Direcciones1/" + IdRegistrado);


            direccion = new List<Direcciones>();


            var responseget = _Client.GetAsync(uriget).Result;

            if (responseget.IsSuccessStatusCode)
            {
                var contentget = await responseget.Content.ReadAsStringAsync();

                direccion = JsonConvert.DeserializeObject<List<Direcciones>>(contentget);

            }

            return direccion;

        }

    }
}
