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
		[Authorize]
		public string InsertarPedido([FromBody] RequestPedido request)
		{
			return System.Text.Json.JsonSerializer.Serialize(PedidoNegocio.insert_Pedido(request));
		}

        [HttpPost("insertpedidodet")]
		[Authorize]
		public string InsertarPedidoDet([FromBody] RequestPedido request)
        {
            return System.Text.Json.JsonSerializer.Serialize(PedidoNegocio.insert_PedidoDet(request));
        }


        [HttpPost("listarpedido")]
		[Authorize]
		public List<ResponsePedido> ListadoPedido([FromBody] RequestPedido request)
		{
			return (PedidoNegocio.ListarPedido(request));
		}	

		[HttpPost("obtenerpedido")]
		[Authorize]
		public List<ResponsePedido> ObtenerPedido([FromBody] RequestPedido request)
		{
			return (PedidoNegocio.ObtenerPedido(request));
		}	
		
		[HttpPost("obtenerpedidodet")]
		[Authorize]
		public List<ResponsePedido> ObtenerPedidodet([FromBody] RequestPedido request)
		{
			return (PedidoNegocio.ObtenerPedido_det(request));
		}


	}
}
