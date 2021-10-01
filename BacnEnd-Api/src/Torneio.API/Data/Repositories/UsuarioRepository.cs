using Torneio.API.Contexts;
using Torneio.API.Models.Entities;
using Torneio.API.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Torneio.API.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(TorneioContext context) : base(context)
        {

        }

        public async Task<Usuario> FindByEmail(string email)
        {
            return await Set.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> UserExists(string email)
        {
            return await Set.AnyAsync(x => x.Email == email);
        }
    }
}
