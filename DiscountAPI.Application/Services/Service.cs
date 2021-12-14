using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DiscountAPI.Application.Services.Interfaces;
using DiscountAPI.Core.Repositories;
using DiscountAPI.Core.UnitOfWorks;

namespace DiscountAPI.Application.Services
{
    public class Service<T> : IService<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IRepository<T> _repository;

        public Service(IUnitOfWork unitOfWork, IRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }


        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate)
        {
            return await _repository.Where(predicate);
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.SingleOrDefaultAsync(predicate);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public void Remove(T entity)
        {
            _repository.Update(entity);
            _unitOfWork.Commit();
        }

        public void Delete(T entity)
        {
            _repository.Remove(entity);
        }

        public T Update(T entity)
        {
            T item = _repository.Update(entity);
            _unitOfWork.Commit();
            return item;
        }
    }
}