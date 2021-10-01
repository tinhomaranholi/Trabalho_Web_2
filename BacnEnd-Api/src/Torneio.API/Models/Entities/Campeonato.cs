using System;
using System.Collections.Generic;

namespace Torneio.API.Models.Entities
{
    public class Campeonato : BaseModel
    {
        public Guid CampeonatoId { get; set; }
        public string Titulo { get; set; }
        public IList<CampeonatoTime> CampeonatoTimes { get; set; }
    }
}
