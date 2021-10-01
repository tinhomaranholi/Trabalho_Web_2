using System;

namespace Torneio.API.Exceptions
{
    public class UsuarioInvalidoException: Exception
    {
        public UsuarioInvalidoException(): base("Usuario ou senha invalido")
        {

        }
    }
}
