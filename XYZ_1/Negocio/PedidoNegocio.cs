using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
	public class PedidoNegocio
	{
		public static ResponsePedido insert_Pedido(RequestPedido request)
		{

			ResponsePedido objRespuesta = new ResponsePedido();
			try
			{
				objRespuesta = PedidosDAO.InsertPedido(request);
			}
			catch (Exception ex)
			{
				objRespuesta.MensajeRespuesta = ex.ToString();
			}
			return objRespuesta;
		}


		public static List<ResponsePedido> ListarProductos(RequestPedido request)
		{

			List<ResponsePedido> objRespuesta = new List<ResponsePedido>();

			try
			{
				objRespuesta = PedidosDAO.listarPedido(request);
			}
			catch (Exception ex)
			{
				//objRespuesta.MensajeRespuesta = ex.ToString();
			}
			return objRespuesta;
		}


	}
}
