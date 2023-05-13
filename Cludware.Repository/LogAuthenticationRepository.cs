using Cludware.Repository.Entities;
using Cludware.Repository.Exceptions;
using Cludware.Repository.Infra;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Cludware.Repository
{
    public interface ILogAuthenticationRepository : IRepositoryBase<LogAuthenticationEntity>
    {
        Task<List<LogAuthenticationEntity>> GetByCreatedAtAsync(DateTime createdAt);
    }

    public class LogAuthenticationRepository : ILogAuthenticationRepository
    {
        private string? _connectionString;
        private readonly IConfiguration _configuration;

        public LogAuthenticationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString($"DefaultConnection");
        }

        public async Task<bool> AddAsync(LogAuthenticationEntity entity)
        {
            try
            {
                var sql = @"INSERT INTO LogAuthentication (LogAuthenticationId, Name, Status, CreatedAt) VALUES (@LogAuthenticationId, @Name, @Status, @CreatedAt)";

                using (var dbConn = new SqlConnection(_connectionString))
                {
                    await dbConn.ExecuteAsync(sql, entity);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new DbConnectionException(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var sql = @"DELETE FROM LogAuthentication WHERE LogAuthenticationId = @LogAuthenticationId";

                using (var dbConn = new SqlConnection(_connectionString))
                {
                    await dbConn.ExecuteAsync(sql, new { LogAuthenticationId = id });
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new DbConnectionException(ex.Message);
            }
        }

        public async Task<List<LogAuthenticationEntity>> GetAllAsync(LogAuthenticationEntity filter)
        {
            try
            {
                var sql = @"SELECT * FROM LogAuthentication WHERE 1 = 1";

                if (filter.LogId > 0)
                    sql = sql + " AND LogId = @LogId";

                if (filter.CreatedAt != null)
                    sql = sql + " AND CreatedAt = @CreatedAt";

                using (var dbConn = new SqlConnection(_connectionString))
                {
                    var results = await dbConn.QueryAsync<LogAuthenticationEntity>(sql, filter);
                    return results.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DbConnectionException(ex.Message);
            }
        }

        public async Task<LogAuthenticationEntity?> GetByIdAsync(int id)
        {
            try
            {
                var sql = @"SELECT * FROM LogAuthentication WHERE LogId = @LogId";

                using (var dbConn = new SqlConnection(_connectionString))
                {
                    var results = await dbConn.QueryAsync<LogAuthenticationEntity>(sql, new { LogId = id });
                    return results.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new DbConnectionException(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(LogAuthenticationEntity entity)
        {
            try
            {
                var sql = @"UPDATE LogAuthentication SET Name = @Name, Status = @Status, EditedAt = @EditedAt WHERE LogId = @LogId";

                using (var dbConn = new SqlConnection(_connectionString))
                {
                    await dbConn.ExecuteAsync(sql, entity);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new DbConnectionException(ex.Message);
            }
        }

        public async Task<List<LogAuthenticationEntity>> GetByCreatedAtAsync(DateTime createdAt)
        {
            try
            {
                var sql = @"SELECT * FROM LogAuthentication WHERE CreatedAt = @createdAt";

                using (var dbConn = new SqlConnection(_connectionString))
                {
                    var results = await dbConn.QueryAsync<LogAuthenticationEntity>(sql, new { CreatedAt = createdAt });
                    return results.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DbConnectionException(ex.Message);
            }
        }
    }
}