using Backend.Ventas.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelDatos.Database;

namespace Backend.Ventas.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactions _tran;

        public TransactionsController(ITransactions iTran)
        {
            _tran = iTran;
        }

        [HttpPost("personas/{TipoPersona}/{Nombre}/{TipoDoc}/{NumDoc}/{Direc}/{Telef}/{Email}")]
        public IActionResult InsertPersona(string TipoPersona, string Nombre, string TipoDoc,
            string NumDoc, string Direc, string Telef, string Email)
        {
            try
            {

                return Ok(_tran.InsertPersona(TipoPersona, Nombre, TipoDoc, NumDoc, Direc, Telef, Email));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("Usuarios")]
        public IActionResult ListUsuarios()
        {
            return Ok(_tran.ListUsuarios);
        }

    }
}
