using FluentValidation;
using NinjaStore.Domain.BaseEntity;
using NinjaStore.Domain.Interfaces.Repositories;
using NinjaStore.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace NinjaStore.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : Entity
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            _repository.Insert(obj);
        }

        public void Delete(TEntity obj)
        {
            _repository.Delete(obj);
        }

        public IEnumerable<TEntity> Get()
        {
            return _repository.Select();
        }

        public TEntity GetById(int id)
        {
            return _repository.Select(id);
        }

        public void Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            _repository.Update(obj);
        }
    }
}
