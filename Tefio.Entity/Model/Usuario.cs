using System;
using System.Collections.Generic;
using System.Text;

namespace Tefio.Entity.Model
{
    public class Usuario
    {
        public String IdUsuario { get; set; }
        public String IdPersona { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String Telefono { get; set; }
        public String Correo { get; set; }
        public bool Estado { get; set; }
        public String TipoUsuario { get; set; }
        public String Token { get; set; }
    }
}
