using System;
using System.Collections.Generic;
using System.Text;

namespace Tefio.Entity.Entity
{
    public class Usuario
    {
        public String IdUsuario { get; set; }
        public String IdPersona { get; set; }
        public String TipoUsuario { get; set; }
        public String Correo { get; set; }
        public String Clave { get; set; }
        public bool Estado { get; set; }
    }
}
