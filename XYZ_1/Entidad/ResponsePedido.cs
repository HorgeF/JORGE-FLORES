using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
	public class ResponsePedido
	{
		public int id_pedido { get; set; }
		public string nro_pedido { get; set; }
		public string fecha_pedido { get; set; }
		public string fecha_recepcion { get; set; }
		public string fecha_despacho { get; set; }
		public string fecha_entrega { get; set; }
		public string id_vendedor { get; set; }
		public int id_estado { get; set; }
		public string estado { get; set; }
		public string uni_medida { get; set; }
		public int id_pedido_det { get; set; }
		public string nombre { get; set; }
		public string sku { get; set; }
		public string tipo { get; set; }
		public decimal precio { get; set; }


		public string MensajeRespuesta { get; set; }
		public string CodigoRespuesta { get; set; }


	}
}
