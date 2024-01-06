using Entidad;
using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace API_2
{

    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

            [HttpPost("auth")]
            public string Login([FromBody] RequestLogin request)
            {
                return System.Text.Json.JsonSerializer.Serialize(LoginNegocio.Login(request));
            }
     

    }
}
