using System.Threading.Tasks;
using Torneio.API.Models.Entities;

namespace Torneio.API.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<bool> UserExists(string email);
        Task<Usuario> FindByEmail(string email);
    }
}
