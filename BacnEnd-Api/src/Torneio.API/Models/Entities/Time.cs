using System;
using System.Collections.Generic;

namespace Torneio.API.Models.Entities
{
    public class Time : BaseModel
    {
        public Guid TimeId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Jogador> Jogadores { get; set; }

        public IList<CampeonatoTime> CampeonatoTimes { get; set; }
    }
}
