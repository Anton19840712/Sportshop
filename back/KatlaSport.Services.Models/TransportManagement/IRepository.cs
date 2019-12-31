using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services
{
    public interface IRepository<TEntity, TUpdateModeRequest>
        where TEntity : class
    {
        Task<TEntity> GetEntityAsync(int id);

        Task<List<TEntity>> GetAllEntitiesAsync();

        Task<TEntity> AddEntityAsync(TUpdateModeRequest entity);

        Task<TEntity> UpdateEntityAsync(TUpdateModeRequest entity, int id);

        Task RemoveEntityAsync(int id);
    }
}
