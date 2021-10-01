using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Torneio.API.Models.Entities
{
    public class Usuario : BaseModel
    {
        public Guid UsuarioId { get; set; }

        public Guid JogadorId { get; set; }

        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }

        public TipoUsuario Role { get; set; }

        public bool SenhasIguais(string senha)
        {
            return Senha.Equals(senha);
        }

    }
}
