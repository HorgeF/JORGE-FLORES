using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public static List<ResponseUsuario> ListarUsuarios(RequestUsuario request)
        {

            List<ResponseUsuario> objRespuesta = new List<ResponseUsuario>();

            try
            {
                objRespuesta = UsuarioDAO.listarUsuarios(request);
            }
            catch (Exception ex)
            {
                //objRespuesta.MensajeRespuesta = ex.ToString();
            }
            return objRespuesta;
        }


    }
}
