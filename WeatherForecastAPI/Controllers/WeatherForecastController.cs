using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using WeatherForecastAPI.Model;
using WeatherForecastAPI.Services;

namespace WeatherForecastAPI.Controllers
{
    [ApiController]
    [Route("api/teste")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IAutenticacaoService _autenticacaoService;

        public WeatherForecastController(IAutenticacaoService autenticacaoService, ILogger<WeatherForecastController> logger)
        {
            _autenticacaoService = autenticacaoService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Teste()
        {

            return Ok();
        }

        [HttpPost("Login2")]
        public async Task<IActionResult> Login(UsuarioLogin usuarioLogin)
        {
            var resposta = await _autenticacaoService.Login(usuarioLogin);

            return Ok();
        }
    }
}
