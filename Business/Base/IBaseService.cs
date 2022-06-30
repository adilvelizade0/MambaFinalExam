using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Base
{
    public interface IBaseService<TEntity>
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> Get(int? id);
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
