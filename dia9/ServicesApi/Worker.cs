
using ServicesApi.Model;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Extensions.Primitives;
using System.Net.Http.Headers;

namespace ServicesApi
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        HttpClient _Client;

        public List<DTOUsuarios>? ListUsuarios;
        public List<DTOCategorias>? ListCategorias;
        public string token = string.Empty;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            _Client = new HttpClient();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);


                //Metodos - GET
                //ASYNCRONICA
                // GetUsuario();
                //GetCategorias();

               
                if(!string.IsNullOrEmpty(token))
                {
                    //realizo los get

                    GetUsuarioToken();
                }
                else
                {
                    //con uso de JWT
                    //generar un token
                    TokenAuth();
                }

                //Metodo - POST
                //PostCategoria();

               
                await Task.Delay(30000, stoppingToken);
            }
        }

        private async void  TokenAuth()
        {

            var login = new DTOAuthInfo
            {
                username = "demo",
                password = "123456"
             
            };

            var json = JsonConvert.SerializeObject(login);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            //2. lLAMAR AL API
            HttpResponseMessage Response = null;

            var uriPostAuthToken = new Uri("http://localhost:5244/api/Token/authenticate");

            Response = await _Client.PostAsync(uriPostAuthToken, content);

            //3. Verificar respuesta
            if (Response.IsSuccessStatusCode)
            {
                token = Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            Console.WriteLine(token);

        }


        private async void GetUsuarioToken()
        {
            //1. lLAMAR AL API

            var urigetUsuarios = new Uri("http://localhost:5244/api/Transactions/usuarios");

            _Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
            var responseUsuarios = await _Client.GetAsync(urigetUsuarios);

            //2. SERIALIZAR

            //verifico respuesta HTTP
            if (responseUsuarios.IsSuccessStatusCode)
            {
                //leer el contenido
                var contentUsuarios = await responseUsuarios.Content.ReadAsStringAsync();

                //Deserializar de Json a objeto
                ListUsuarios = JsonConvert.DeserializeObject<List<DTOUsuarios>>(contentUsuarios);
            }

            //3. MOSTRAR EN PANTALLA
            if (ListUsuarios.Count > 0)
            {
                for (int l = 0; l < ListUsuarios.Count; l++)
                {
                    Console.WriteLine(ListUsuarios[l].Usuario + "-" + ListUsuarios[l].Registrado);
                }

            }

        }

        private async void PostCategoria()
        {

            //1. SERIALIZAR a JSON

            var item = new DTOCategorias
            {
                Idcategoria = 0,
                Nombre = "API:" + DateTime.Now.Ticks.ToString(),
                Descripcion = "NAC",
                Estado = true
            };

            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            //2. lLAMAR AL API
            HttpResponseMessage Response = null;

            var uriPostCategoiria = new Uri("http://localhost:5244/api/Categorias/registro");

            Response = await _Client.PostAsync(uriPostCategoiria, content);

            //3. Verificar respuesta
            if(Response.IsSuccessStatusCode)
            {

                //4. Tomo respuesta y Mostrar pantalla

                Console.WriteLine("Registro Exitoso:- " + Response.ToString());

            }
            else
            {
                Console.WriteLine(Response.Content.ReadAsStringAsync());
            }


        }

        private async void GetUsuario()
        {
            //1. lLAMAR AL API

            var urigetUsuarios = new Uri("http://localhost:5244/api/Transactions/usuarios");

            var responseUsuarios = await _Client.GetAsync(urigetUsuarios);

            //2. SERIALIZAR

            //verifico respuesta HTTP
            if (responseUsuarios.IsSuccessStatusCode)
            {
                //leer el contenido
                var contentUsuarios = await responseUsuarios.Content.ReadAsStringAsync();

                //Deserializar de Json a objeto
                ListUsuarios = JsonConvert.DeserializeObject<List<DTOUsuarios>>(contentUsuarios);
            }

            //3. MOSTRAR EN PANTALLA
            if(ListUsuarios.Count > 0)
            {
                for(int l= 0; l < ListUsuarios.Count; l++)
                {
                    Console.WriteLine(ListUsuarios[l].Usuario + "-" + ListUsuarios[l].Registrado);
                }

            }

        }

        private async void GetCategorias()
        {
            //1. lLAMAR AL API
            var urigetCategorias = new Uri("http://localhost:5244/api/Categorias");

            var responseCategorias = await _Client.GetAsync(urigetCategorias);

            //2. SERIALIZAR

            //verifico respuesta HTTP
            if (responseCategorias.IsSuccessStatusCode)
            {
                //leer el contenido
                var contentCategorias = await responseCategorias.Content.ReadAsStringAsync();

                //Deserializar de Json a objeto
                ListCategorias = JsonConvert.DeserializeObject<List<DTOCategorias>>(contentCategorias);
            }

            //3. MOSTRAR EN PANTALLA
            if (ListCategorias.Count > 0)
            {
                for (int l = 0; l < ListCategorias.Count; l++)
                {
                    Console.WriteLine(ListCategorias[l].Nombre + "-" + ListCategorias[l].Descripcion);
                }

            }

        }

    }
}
