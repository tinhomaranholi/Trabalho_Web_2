using System;

namespace Torneio.API.Models.Dtos
{
    public class DetailTimeDto
    {
        public Guid TimeId { get; set; }
        public string Nome { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
