using Backend.Ventas.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Ventas.Services
{
    public class JwtAuthenticationServices : IJwtAuthentication
    {

        private readonly string _key;

        public JwtAuthenticationServices(string key) 
        {
            _key = key;
        }

        public string Authenticate(string username, string password)
        {
            //logica q verifique credenciales de acceso
            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)
                || username != "demo" || password != "123456")
            {
                return string.Empty;
            }

            //Proceso para formar un JWT
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenkey = Encoding.ASCII.GetBytes(_key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(1),
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, username)
                        ,new Claim(ClaimTypes.Email, "vidapogosoft@gmail.com"),
                        new Claim(ClaimTypes.Role, "usuario")
                    }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}
