namespace Cludware.Repository.Infra.Cache
{
    public interface ICacheRepository
    {
        /// <summary>
        /// Adiciona um objeto ao cache.
        /// </summary>
        /// <param name="key">Chave do item de cache.</param>
        /// <param name="value">Objeto de valor a ser armazenado.</param>
        Task AddAsync<TEntity>(string key, TEntity value);

        /// <summary>
        /// Adiciona um objeto ao cache com tempo determinado para expiração.
        /// </summary>
        /// <param name="key">Chave do item de cache.</param>
        /// <param name="value">Objeto de valor a ser armazenado.</param>
        /// <param name="minutes">Minutos que permanecera em cache o item, após isso sera expirado.</param>
        Task AddAsync<TEntity>(string key, TEntity value, double minutes);

        /// <summary>
        /// Atualiza um objeto ja adicionado anteriormente em cache.
        /// </summary>
        /// <param name="key">Chave do item de cache.</param>
        /// <param name="value">Objeto de valor a ser armazenado.</param>
        Task UpdateAsync<TEntity>(string key, TEntity value);

        /// <summary>
        /// Atualiza um objeto ja adicionado anteriormente em cache e assume tempo de expiração novamente.
        /// </summary>
        /// <param name="key">Chave do item de cache.</param>
        /// <param name="value">Objeto de valor a ser armazenado.</param>
        /// <param name="minutes">Minutos que permanecera em cache o item, após isso sera expirado.</param>
        Task UpdateAsync<TEntity>(string key, TEntity value, double minutes);

        /// <summary>
        /// Obtem o um item em cache.
        /// </summary>
        /// <param name="key">Chave do item de cache.</param>
        /// <returns>Obtem objeto de valor armazenado.</returns>
        Task<TEntity?> GetAsync<TEntity>(string key);

        /// <summary>
        /// Remove o um item em cache.
        /// </summary>
        /// <param name="key"></param>
        Task RemoveAsync(string key);

        /// <summary>
        /// Remove todos os itens em cache.
        /// </summary>
        Task ClearAllDataBaseAsync();

        /// <summary>
        /// Remove um item expecifico, 0 é o banco de dados padrão.
        /// </summary>
        /// <param name="database">Número do banco de dados.</param>
        Task ClearDataBaseAsync(int database);

        /// <summary>
        /// Verifica a existencia de um item em cache pelo nome de sua chave.
        /// </summary>
        /// <param name="key">Chave do item de cache.</param>
        /// <returns>Retorna verdadeiro se existir e falso se não existir.</returns>
        Task<bool> ExistsAsync(string key);
    }
}
