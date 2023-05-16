using Cludware.Repository.Entities;
using Cludware.Repository.Exceptions;
using Cludware.Repository.Infra;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Cludware.Repository
{
    public interface ICompanyRepository : IRepositoryBase<CompanyEntity>
    {

    }

    public class CompanyRepository : ICompanyRepository
    {
        private string? _connectionString;
        private readonly IConfiguration _configuration;

        public CompanyRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString($"DefaultConnection");
        }

        public async Task<bool> AddAsync(CompanyEntity entity)
        {
            try
            {
                var sql = @"INSERT INTO Company (CompanyId, Name, Status, CreatedAt) VALUES (@CompanyId, @Name, @Status, @CreatedAt)";

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
                var sql = @"DELETE FROM Company WHERE CompanyId = @CompanyId";

                using (var dbConn = new SqlConnection(_connectionString))
                {
                    await dbConn.ExecuteAsync(sql, new { CompanyId = id });
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new DbConnectionException(ex.Message);
            }
        }

        public async Task<List<CompanyEntity>> GetAllAsync(CompanyEntity filter)
        {
            try
            {
                var sql = @"SELECT * FROM Company WHERE 1 = 1";

                if (filter.CompanyId > 0)
                    sql = sql + " AND CompanyId = @CompanyId";

                if (!string.IsNullOrEmpty(filter.LegalEntityName))
                    sql = sql + " AND LegalEntityName = @LegalEntityName";

                if (!string.IsNullOrEmpty(filter.LegalFantasyName))
                    sql = sql + " AND LegalFantasyName = @LegalFantasyName";

                if (filter.CreatedAt != null)
                    sql = sql + " AND CreatedAt = @CreatedAt";

                using (var dbConn = new SqlConnection(_connectionString))
                {
                    var results = await dbConn.QueryAsync<CompanyEntity>(sql, filter);
                    return results.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DbConnectionException(ex.Message);
            }
        }

        public async Task<CompanyEntity?> GetByIdAsync(int id)
        {
            try
            {
                var sql = @"SELECT * FROM Company WHERE CompanyId = @CompanyId";

                using (var dbConn = new SqlConnection(_connectionString))
                {
                    var results = await dbConn.QueryAsync<CompanyEntity>(sql, new { CompanyId = id });
                    return results.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new DbConnectionException(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(CompanyEntity entity)
        {
            try
            {
                var sql = @"UPDATE Company SET Name = @Name, Status = @Status, EditedAt = @EditedAt WHERE CompanyId = @CompanyId";

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