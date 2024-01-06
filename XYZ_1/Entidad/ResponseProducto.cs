using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
	public  class ResponseProducto
	{
		    public string id_producto {  get; set; }
			public string sku {  get; set; }
			public string nombre {  get; set; }
			public string tipo {  get; set; }
			public string etiquetas {  get; set; }
			public string precio {  get; set; }
			public string uni_medida {  get; set; }
	}
}
