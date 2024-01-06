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
    public static  class LoginDAO
    {

        public static ResponseLogin Login(RequestLogin request)
        {
            Database objDB = Data.CnGeneral;
            DbCommand objCMD = objDB.GetStoredProcCommand("SP_GET_USUARIO");
            objDB.AddInParameter(objCMD, "@usuario", DbType.String, request.Usuario);
            objDB.AddInParameter(objCMD, "@contrasenia", DbType.String, request.Contrasena);

            var lst = new ResponseLogin();

            using (IDataReader dr = objDB.ExecuteReader(objCMD))
            {
                while (dr.Read())
                {


                    lst.nombre = Data.reader(dr, "usuario");
                    lst.correo   = Data.reader(dr, "correo");
                    lst.puesto = Data.reader(dr, "puesto");
                    lst.cod_trabajador = Data.reader(dr, "cod_trabajador");
                    lst.id_rol = Convert.ToInt32(Data.reader(dr, "id_rol"));



                }
            }

            return lst;

        }
    }
}
