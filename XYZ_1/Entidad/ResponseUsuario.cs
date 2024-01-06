using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Entidad
{
    public class ResponseUsuario
    {

        public string cod_trabajador {  get; set; }
        public string nombre {get; set; }
        public string correo {get; set; }
        public string telefono { get; set; }
        public string puesto { get; set; }
        public string id_rol {get; set; }
    }
}
