using System;

namespace Torneio.API.Models.Entities
{
    public class Resultado : BaseModel
    {
        public Guid ResultadoId { get; set; }
        public Time TimeVencedor { get; set; }
        public DateTime DataOcorrencia { get; set; }
    }
}
