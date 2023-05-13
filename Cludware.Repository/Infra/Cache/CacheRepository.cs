using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Cludware.Repository.Infra.Cache
{
    public class CacheRepository : ICacheRepository
    {
        private string? _cacheConnectionString;
        private readonly ConnectionMultiplexer _connectionMultiplexer;
        private readonly IDatabase _redisDb;
        private readonly IConfiguration _configuration;

        public CacheRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _cacheConnectionString = _configuration.GetConnectionString("Cache");

            if (string.IsNullOrEmpty(_cacheConnectionString))
                throw new ArgumentNullException($"A connection de cache não pode ser nula no arquivo de configuração.");

            _connectionMultiplexer = ConnectionMultiplexer.Connect(_cacheConnectionString);
            _redisDb = _connectionMultiplexer.GetDatabase();
        }

        public async Task AddAsync<TEntity>(string key, TEntity value)
        {
            try
            {
                await Task.Run(() =>
                {
                    var serializeObject = JsonConvert.SerializeObject(value);
                    _redisDb.StringSet(key, serializeObject);
                });
            }
            catch (Exception ex)
            {
                throw ThrowException(ex);
            }
        }

        public async Task AddAsync<TEntity>(string key, TEntity value, double minutes)
        {
            try
            {
                await Task.Run(() =>
                {
                    var timeSpan = TimeSpan.FromMinutes(minutes);
                    var serializeObject = JsonConvert.SerializeObject(value);
                    _redisDb.StringSet(key, serializeObject, timeSpan);
                });
            }
            catch (Exception ex)
            {
                throw ThrowException(ex);
            }
        }

        public async Task UpdateAsync<TEntity>(string key, TEntity value)
        {
            try
            {
                await Task.Run(async () =>
                {
                    var isExistsKeyInCache = await ExistsAsync(key);
                    if (isExistsKeyInCache)
                    {
                        await RemoveAsync(key);
                        await AddAsync(key, value);
                    }
                });
            }
            catch (Exception ex)
            {
                throw ThrowException(ex);
            }
        }

        public async Task UpdateAsync<TEntity>(string key, TEntity value, double minutes)
        {
            try
            {
                await Task.Run(async () =>
                {
                    var isExistsKeyInCache = await ExistsAsync(key);
                    if (isExistsKeyInCache)
                    {
                        await RemoveAsync(key);
                        await AddAsync(key, value, minutes);
                    }
                });
            }
            catch (Exception ex)
            {
                throw ThrowException(ex);
            }
        }

        public Task<TEntity?> GetAsync<TEntity>(string key)
        {
            try
            {
                return Task.Run(() =>
                {
                    var value = _redisDb.StringGet(key);
                    if (!value.IsNull)
                        return JsonConvert.DeserializeObject<TEntity>(value);
                    else
                        return default(TEntity);
                });
            }
            catch (Exception ex)
            {
                throw ThrowException(ex);
            }
        }

        public async Task RemoveAsync(string key)
        {
            try
            {
                await Task.Run(() =>
                {
                    _redisDb.KeyDelete(key);
                });
            }
            catch (Exception ex)
            {
                throw ThrowException(ex);
            }
        }

        public async Task ClearAllDataBaseAsync()
        {
            try
            {
                await Task.Run(() =>
                {
                    var endpoints = _connectionMultiplexer.GetEndPoints(true);
                    foreach (var endpoint in endpoints)
                    {
                        var server = _connectionMultiplexer.GetServer(endpoint);
                        server.FlushAllDatabases(); // Limpa todos os banco de dados.
                    }
                });
            }
            catch (Exception ex)
            {
                throw ThrowException(ex);
            }
        }

        public async Task ClearDataBaseAsync(int database)
        {
            try
            {
                await Task.Run(() =>
                {
                    var endpoints = _connectionMultiplexer.GetEndPoints(true);
                    foreach (var endpoint in endpoints)
                    {
                        var server = _connectionMultiplexer.GetServer(endpoint);
                        server.FlushDatabase(database); // limpa apenas um banco de dados, 0 by default.
                    }
                });
            }
            catch (Exception ex)
            {
                throw ThrowException(ex);
            }
        }

        public async Task<bool> ExistsAsync(string key)
        {
            try
            {
                return await Task.Run(() =>
                {
                    return _redisDb.KeyExists(key);
                });
            }
            catch (Exception ex)
            {
                throw ThrowException(ex);
            }
        }

        private Exception ThrowException(Exception exception)
        {
            var message = string.Empty;

            if (exception.InnerException == null)
                message = $"{message} {exception.Message}";
            else
                message = $"{message} {exception.InnerException.Message}";

            return new Exception(message);
        }
    }
}
