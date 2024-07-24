using Backend.Ventas.Interfaces;
using Backend.Ventas.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Ventas.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        private readonly IJwtAuthentication _auth;

        public TokenController(IJwtAuthentication auth)
        {
            _auth = auth;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] DTOAuthInfo user)
        {
            var token = _auth.Authenticate(user.username, user.password);

            if(token == string.Empty)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

    }
}
