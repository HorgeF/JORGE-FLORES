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
    public  class UsuarioDAO
    {


        public static List<ResponseUsuario> listarUsuarios(RequestUsuario request)
        {
            Database objDB = Data.CnGeneral;
            DbCommand objCMD = objDB.GetStoredProcCommand("SP_LISTAR_USUARIOS");
            objDB.AddInParameter(objCMD, "@id_rol", DbType.Int32, request.id_rol);

            var lst = new List<ResponseUsuario>();


            using (IDataReader dr = objDB.ExecuteReader(objCMD))
            {
                while (dr.Read())
                {
                    var entidad = new ResponseUsuario();
                    entidad.cod_trabajador = Convert.ToString(Data.reader(dr, "cod_trabajador"));
                    entidad.nombre = Convert.ToString(Data.reader(dr, "nombre"));
                    entidad.correo = Convert.ToString(Data.reader(dr, "correo"));
                    entidad.telefono = Convert.ToString(Data.reader(dr, "telefono"));
                    entidad.puesto = Convert.ToString(Data.reader(dr, "puesto"));
                    entidad.id_rol = Convert.ToString(Data.reader(dr, "id_rol"));
                    //entidad.fechaRegistro = Convert.ToDateTime(Data.reader(dr, "fechaRegistro"));


                    lst.Add(entidad);
                }
            }

            return lst;

        }

    }
}
