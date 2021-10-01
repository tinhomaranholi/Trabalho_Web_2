using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Torneio.API.Models.Entities;

namespace Torneio.API.Interfaces
{
    public interface IRepository<T> where T: BaseModel
    {
        Task<T> Add(T entity);
        Task<List<T>> Get();
        Task<T> Get(Guid id);
        Task Remove(Guid id);
        Task<T> Update(Guid id, T entity);
    }
}
