using FluentValidation;
using NinjaStore.Domain.BaseEntity;
using System.Collections.Generic;

namespace NinjaStore.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : Entity
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> Get();
        void Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
        void Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
        void Delete(TEntity obj);
    }
}
