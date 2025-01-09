using Application.Services.Base;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implements.Base
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly GenericRepository<T> _repository;

        public GenericService(GenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync($"SELECT * FROM {typeof(T).Name}");
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync($"SELECT * FROM {typeof(T).Name} WHERE Id = @Id", new { Id = id });
        }

        public async Task AddAsync(T entity)
        {
            await _repository.InsertAsync($"INSERT INTO {typeof(T).Name} (...) VALUES (...)", entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await _repository.UpdateAsync($"UPDATE {typeof(T).Name} SET ... WHERE Id = @Id", entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync($"DELETE FROM {typeof(T).Name} WHERE Id = @Id", new { Id = id });
        }
    }
}
