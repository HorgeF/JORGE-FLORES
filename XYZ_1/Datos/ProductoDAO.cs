using Entidad;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
	public  class ProductoDAO
	{

		public static List<ResponseProducto> listarProducto(RequestProducto request)
		{
			Database objDB = Data.CnGeneral;
			DbCommand objCMD = objDB.GetStoredProcCommand("SP_LISTAR_PRODUCTOS");
			objDB.AddInParameter(objCMD, "@SKU", DbType.String, request.sku);
			objDB.AddInParameter(objCMD, "@NOMBRE", DbType.String, request.nombre);

			var lst = new List<ResponseProducto>();


			using (IDataReader dr = objDB.ExecuteReader(objCMD))
			{
				while (dr.Read())
				{
					var entidad = new ResponseProducto();
					entidad.id_producto = Convert.ToInt32(Data.reader(dr, "id_producto")).ToString();
					entidad.sku = Convert.ToString(Data.reader(dr, "sku"));
					entidad.nombre = Convert.ToString(Data.reader(dr, "nombre"));
					entidad.tipo = Convert.ToString(Data.reader(dr, "tipo"));
					entidad.etiquetas = Convert.ToString(Data.reader(dr, "etiquetas"));
					entidad.precio = Convert.ToDecimal(Data.reader(dr, "precio")).ToString();
					entidad.uni_medida = Convert.ToString(Data.reader(dr, "uni_medida"));
					//entidad.fechaRegistro = Convert.ToDateTime(Data.reader(dr, "fechaRegistro"));


					lst.Add(entidad);
				}
			}

			return lst;

		}
	}
}
