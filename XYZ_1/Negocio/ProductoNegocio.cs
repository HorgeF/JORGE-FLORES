using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
	public  class ProductoNegocio
	{

		public static List<ResponseProducto> ListarProductos(RequestProducto request)
		{

			List<ResponseProducto> objRespuesta = new List<ResponseProducto>();

			try
			{
				objRespuesta = ProductoDAO.listarProducto(request);
			}
			catch (Exception ex)
			{
				//objRespuesta.MensajeRespuesta = ex.ToString();
			}
			return objRespuesta;
		}

	}
}
