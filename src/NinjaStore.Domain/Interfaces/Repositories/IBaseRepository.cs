using System;
using System.Collections.Generic;

namespace NinjaStore.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        IList<TEntity> Select();
        TEntity Select(Guid id);
    }
}
