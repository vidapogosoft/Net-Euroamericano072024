using Backend.Ventas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ModelDatos.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Ventas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Categorias : ControllerBase
    {


        private readonly ICategorias _categ;

        public Categorias(ICategorias icateg)
        {
            _categ = icateg;
        }

        // GET: api/<Categorias>
        [HttpGet]
        public IActionResult GetCategorias()
        {
            return Ok(_categ.ListCategorias);
        }

        // GET api/<Categorias>/5
        [HttpGet("origen/{origen}")]
        public IActionResult GetCategoriasByOrigen(string origen)
        {
            return Ok(_categ.ListCategoriaByOrigen(origen));
        }


        [HttpGet("estado/{estado}")]
        public IActionResult GetCategoriasByEstado(bool estado)
        {
            return Ok(_categ.ListCategoriaByEstado(estado));
        }

		// GET api/<Categorias>/5
		[HttpGet("id/{Idcategoria}")]
		public IActionResult CategoriaById(int Idcategoria)
		{
			return Ok(_categ.CategoriaById(Idcategoria));
		}

		// POST api/<Categorias>
		[HttpPost("registro")]
        public IActionResult InsertCategoria([FromBody] Categorium NewItem)
        {
            try
            {
                if( NewItem == null || !ModelState.IsValid)
                {
                    return BadRequest("Error en registro en base de datos Modelo no valido");
                }

                _categ.InsertCategoria(NewItem);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok(NewItem);

        }

        [HttpPost("registro1")]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<Categorias>/5
        [HttpPut("upd1")]
        public IActionResult UpdateCategoria([FromBody] Categorium UpdItem)
        {
            try
            {
                if (UpdItem == null || !ModelState.IsValid)
                {
                    return BadRequest("Error en envio de datos Modelo no valido");
                }

                _categ.UpdateCategoria(UpdItem);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPut("upd2/{Idcategoria}/{Descr}/{Nombre}")]
        public IActionResult UpdateCategoria2(int Idcategoria, string Descr, string Nombre)
        {
            try
            {
                _categ.UpdateCategoria2(Idcategoria, Descr, Nombre);

            }
            catch (Exception ex)
            {
                return BadRequest("Error:" + ex.Message);
            }

            return Ok();
        }

        // DELETE api/<Categorias>/5

        [HttpDelete("delete1/{Idcategoria}")]
        public IActionResult DeleteCategoria1(int Idcategoria)
        {
            try
            {

                _categ.DeleteCategoria(Idcategoria);

            }
            catch (Exception ex)
            {
                return BadRequest("Error:" + ex.Message);
            }

            return Ok();
        }


        [HttpDelete("delete2")]
        public IActionResult DeleteCategoria2([FromBody] Categorium DelItem)
        {
            try
            {
                if (DelItem == null || !ModelState.IsValid)
                {
                    return BadRequest("Error en Modelo no valido");
                }

                _categ.DeleteCategoria2(DelItem);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok();

        }

    }
}
