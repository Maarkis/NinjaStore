using FluentValidation;
using NinjaStore.Domain.BaseEntity;
using System.Collections.Generic;

namespace NinjaStore.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : Entity
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> Get();
        TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
        TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
        void Delete(int id);
    }
}
