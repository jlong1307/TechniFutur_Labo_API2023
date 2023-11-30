using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.Services
{
    public interface IRepository<TKey, TEntity>
    {
        IEnumerable<TEntity> GetAll();

        TEntity? GetById(TKey id);

        TEntity? Create(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(TEntity entity);
    }
}
