using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
	public class RequestPedido
	{

		public int accion {  get; set; }
		public int id_pedido { get; set; }
		public string fecha_pedido { get; set; } = string.Empty;
		public string fecha_recepcion { get; set; } = string.Empty;
		public string fecha_despacho { get; set; } = string.Empty;
		public string fecha_entrega { get; set; } = string.Empty;
		public string fecha { get; set; } = string.Empty;
		public int id_vendedor { get; set; }
		public string n_pedido { get; set; } = string.Empty;
		public int id_estado { get; set; }
		public int id_result { get; set; }
		public decimal precio { get; set; }
		public int id_pedido_det { get; set; }
		public int id_producto { get; set; }

	}
}
