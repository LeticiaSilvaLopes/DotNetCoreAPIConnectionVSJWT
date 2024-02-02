using WeatherForecastAPI.Model;

namespace WeatherForecastAPI.Services
{
    public interface IAutenticacaoService
    {
        Task<string> Login(UsuarioLogin usuarioLogin);

    }
}
