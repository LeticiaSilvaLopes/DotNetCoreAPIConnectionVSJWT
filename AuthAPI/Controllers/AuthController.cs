using AuthAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AuthAPI.Controllers
{
    [ApiController]
    [Route("api/conta")]
    public class AuthController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;

        public AuthController(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserViewModel loginUser)
        {
            if(loginUser.Email == "lopes20leticia@gmail.com" && loginUser.Password == "123456")
            {

            }

            return Ok(GerarJwt());
        }

        private string GerarJwt()
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtSettings.Segredo);

                var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = _jwtSettings.Emissor,
                    Audience = _jwtSettings.Audiencia,
                    Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpiracaoHoras),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                });

                var encodedToken = tokenHandler.WriteToken(token);

                return encodedToken;
            }
            catch (Exception ex)
            {
                var teste = ex.Message;
                throw;
            }
        }
    }
}
