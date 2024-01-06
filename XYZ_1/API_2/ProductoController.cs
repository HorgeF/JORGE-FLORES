using Entidad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace API_2
{
	[Route("[controller]")]
	[ApiController]
	public class ProductoController : ControllerBase
	{


		[HttpPost("listarproductos")]
		[Authorize]
		public List<ResponseProducto> ListadoProductos([FromBody] RequestProducto request)
		{
			return (ProductoNegocio.ListarProductos(request));
		}

	}
}
