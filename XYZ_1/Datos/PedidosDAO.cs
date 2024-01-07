using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Datos
{
	public class PedidosDAO
	{
		public static ResponsePedido InsertPedido(RequestPedido request)
		{
			Database objDB = Data.CnGeneral;

			DbCommand objCMD = objDB.GetStoredProcCommand("USP_INS_PEDIDO_CAB");

			objDB.AddInParameter(objCMD, "@ACCION", DbType.Int32, request.accion);
			objDB.AddInParameter(objCMD, "@FECHA", DbType.String, request.fecha_pedido ?? "");
			//objDB.AddInParameter(objCMD, "@FECHA_RECEPCION", DbType.String, request.fecha_recepcion ?? "");
			//objDB.AddInParameter(objCMD, "@FECHA_DESPACHO", DbType.String, request.fecha_despacho ?? "");
			//objDB.AddInParameter(objCMD, "@FECHA_ENTREGA", DbType.String, request.fecha_entrega ?? "");
			objDB.AddInParameter(objCMD, "@ID_VENDEDOR", DbType.Int32, request.id_vendedor);
			objDB.AddInParameter(objCMD, "@ID_ESTADO", DbType.Int32, request.id_estado);
			objDB.AddOutParameter(objCMD,"@ID_PEDIDO", DbType.Int32, request.id_pedido);


			objDB.ExecuteNonQuery(objCMD);

			var idPedido = Int32.Parse(objDB.GetParameterValue(objCMD, "@ID_PEDIDO").ToString() ?? "0");

			var lst = new ResponsePedido();
			if (idPedido > 0)
				lst.MensajeRespuesta = "Proceso correctamente.";
			lst.CodigoRespuesta = "001";

			return lst;

		}



		public static List<ResponsePedido> listarPedido(RequestPedido request)
		{
			Database objDB = Data.CnGeneral;
			DbCommand objCMD = objDB.GetStoredProcCommand("SP_LISTAR_PEDIDOS");
			objDB.AddInParameter(objCMD, "@NRO_PEDIDO", DbType.String, request.n_pedido);


			var lst = new List<ResponsePedido>();


			using (IDataReader dr = objDB.ExecuteReader(objCMD))
			{
				while (dr.Read())
				{
					var entidad = new ResponsePedido();
					entidad.id_pedido = Convert.ToInt32(Data.reader(dr, "id_pedido"));
					entidad.nro_pedido = Convert.ToString(Data.reader(dr, "nro_pedido"));
					entidad.fecha_pedido = Convert.ToString(Data.reader(dr, "fecha_pedido"));
					entidad.fecha_despacho = Convert.ToString(Data.reader(dr, "fecha_despacho"));
					entidad.fecha_entrega = Convert.ToString(Data.reader(dr, "fecha_entrega"));
					entidad.id_estado = Convert.ToString(Data.reader(dr, "uni_medida"));
					entidad.estado = Convert.ToString(Data.reader(dr, "estado"));
					//entidad.fechaRegistro = Convert.ToDateTime(Data.reader(dr, "fechaRegistro"));


					lst.Add(entidad);
				}
			}

			return lst;

		}
	}
}
