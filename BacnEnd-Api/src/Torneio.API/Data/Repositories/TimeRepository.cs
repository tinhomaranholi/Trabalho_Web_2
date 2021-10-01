using Torneio.API.Contexts;
using Torneio.API.Models.Entities;
using Torneio.API.Interfaces;

namespace Torneio.API.Repositories
{
    public class TimeRepository : RepositoryBase<Time>, ITimeRepository
    {
        public TimeRepository(TorneioContext context): base(context)
        {

        }
    }
}
