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

        [HttpPost("insertpedidodet")]
        public string InsertarPedidoDet([FromBody] RequestPedido request)
        {
            return System.Text.Json.JsonSerializer.Serialize(PedidoNegocio.insert_PedidoDet(request));
        }


        [HttpPost("listarpedido")]
		public List<ResponsePedido> ListadoPedido([FromBody] RequestPedido request)
		{
			return (PedidoNegocio.ListarPedido(request));
		}	

		[HttpPost("obtenerpedido")]
		public List<ResponsePedido> ObtenerPedido([FromBody] RequestPedido request)
		{
			return (PedidoNegocio.ObtenerPedido(request));
		}	
		
		[HttpPost("obtenerpedidodet")]
		public List<ResponsePedido> ObtenerPedidodet([FromBody] RequestPedido request)
		{
			return (PedidoNegocio.ObtenerPedido_det(request));
		}


	}
}
