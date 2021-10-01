using System;

namespace Torneio.API.Models.Entities
{
    public class CampeonatoTime
    {
        public Guid TimeId { get; set; }
        public Time Time { get; set; }

        public Guid CampeonatoId { get; set; }
        public Campeonato Campeonato { get; set; }
    }
}
