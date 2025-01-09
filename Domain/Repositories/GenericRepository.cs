using System;
using System.Collections.Generic;
using System.Data;
using Dapper;


namespace Domain.Repositories
{
    public class GenericRepository<T> where T : class
    {
        private readonly IDbConnection _dbConnection;

        public GenericRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string query)
        {
            return await _dbConnection.QueryAsync<T>(query);
        }

        public async Task<T> GetByIdAsync(string query, object parameters)
        {
            return await _dbConnection.QueryFirstOrDefaultAsync<T>(query, parameters);
        }

        public async Task<int> InsertAsync(string query, object parameters)
        {
            return await _dbConnection.ExecuteAsync(query, parameters);
        }

        public async Task<int> UpdateAsync(string query, object parameters)
        {
            return await _dbConnection.ExecuteAsync(query, parameters);
        }

        public async Task<int> DeleteAsync(string query, object parameters)
        {
            return await _dbConnection.ExecuteAsync(query, parameters);
        }
    }
}
