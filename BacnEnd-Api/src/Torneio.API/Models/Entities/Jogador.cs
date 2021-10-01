using System;

namespace Torneio.API.Models.Entities
{
    public class Jogador : BaseModel
    {
        public Guid JogadorId { get; set; }
        public string Nome { get; set; }
        public Guid TimeId { get; set; }
        public virtual Time Time { get; set; }

    }
}
