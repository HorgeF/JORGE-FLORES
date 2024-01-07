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
		public string id_estado { get; set; }
		public string estado { get; set; }

		public string MensajeRespuesta { get; set; }
		public string CodigoRespuesta { get; set; }


	}
}
