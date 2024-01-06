using Entidad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace API_2
{
    [Route("[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        [HttpPost("listarusuarios")]
        [Authorize]
        public List<ResponseUsuario> ListadoUsuarios([FromBody] RequestUsuario request)
        {
            return (UsuarioNegocio.ListarUsuarios(request));
        }

    }
}
