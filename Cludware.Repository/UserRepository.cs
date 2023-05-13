using Cludware.Repository.Entities;
using Cludware.Repository.Exceptions;
using Cludware.Repository.Infra;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Cludware.Repository
{
    public interface IUserRepository : IRepositoryBase<UserEntity>
    {
        Task<bool> UpdatePasswordAsync(UserEntity entity);

        Task<UserEntity?> GetByLoginAsync(string email, string password);
    }

    public class UserRepository : IUserRepository
    {
        private string? _connectionString;
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString($"DefaultConnection");
        }

        public async Task<bool> AddAsync(UserEntity entity)
        {
            try
            {
                var sql = @"INSERT INTO User (UserId, Name, Status, CreatedAt) VALUES (@UserId, @Name, @Status, @CreatedAt)";

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
                var sql = @"DELETE FROM User WHERE UserId = @UserId";

                using (var dbConn = new SqlConnection(_connectionString))
                {
                    await dbConn.ExecuteAsync(sql, new { UserId = id });
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new DbConnectionException(ex.Message);
            }
        }

        public async Task<List<UserEntity>> GetAllAsync(UserEntity filter)
        {
            try
            {
                var sql = @"SELECT * FROM User WHERE 1 = 1";

                if (filter.UserId > 0)
                    sql = sql + " AND UserId = @UserId";

                if (!string.IsNullOrEmpty(filter.Name))
                    sql = sql + " AND Name = @Name";

                if (filter.CreatedAt != null)
                    sql = sql + " AND CreatedAt = @CreatedAt";

                using (var dbConn = new SqlConnection(_connectionString))
                {
                    var results = await dbConn.QueryAsync<UserEntity>(sql, filter);
                    return results.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DbConnectionException(ex.Message);
            }
        }

        public async Task<UserEntity?> GetByIdAsync(int id)
        {
            try
            {
                var sql = @"SELECT * FROM User WHERE UserId = @UserId";

                using (var dbConn = new SqlConnection(_connectionString))
                {
                    var results = await dbConn.QueryAsync<UserEntity>(sql, new { UserId = id });
                    return results.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new DbConnectionException(ex.Message);
            }
        }

        public async Task<UserEntity?> GetByLoginAsync(string email, string password)
        {
            try
            {
                var sql = @"SELECT * FROM User WHERE Email=@Email AND Password=@Password";

                using (var dbConn = new SqlConnection(_connectionString))
                {
                    var results = await dbConn.QueryAsync<UserEntity>(sql, new { Email = email, Password = password });
                    return results.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new DbConnectionException(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(UserEntity entity)
        {
            try
            {
                var sql = @"UPDATE User SET Name = @Name, Status = @Status, EditedAt = @EditedAt WHERE UserId = @UserId";

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

        public async Task<bool> UpdatePasswordAsync(UserEntity entity)
        {
            try
            {
                var sql = @"UPDATE User SET Password = @Password WHERE UserId = @UserId";

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
    }
}