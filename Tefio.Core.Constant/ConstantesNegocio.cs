using System;

namespace Tefio.Core.Constant
{
    public static class ConstantesNegocio
    {
        public class Login
        {
            public const int MaxIntentosFallidos = 3;
            public const bool EstadoUsuario_Activo = true;
            public const int TiempoDeLogueo = 525600;//Minutos 525600->1año
        }
    }
}
