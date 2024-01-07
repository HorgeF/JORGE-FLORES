using Entidad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace API_2
{

    [Route("[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {


		[HttpPost("insertpedido")]
		public string InsertarPedido([FromBody] RequestPedido request)
		{
			return System.Text.Json.JsonSerializer.Serialize(PedidoNegocio.insert_Pedido(request));
		}


		[HttpPost("listarpedido")]
		public List<ResponsePedido> ListadoPedido([FromBody] RequestPedido request)
		{
			return (PedidoNegocio.ListarProductos(request));
		}


	}
}
