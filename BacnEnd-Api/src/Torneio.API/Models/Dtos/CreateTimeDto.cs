using System.ComponentModel.DataAnnotations;

namespace Torneio.API.Models.Dtos
{
    public class CreateTimeDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
    }
}
