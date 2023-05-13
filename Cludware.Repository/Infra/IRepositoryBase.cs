namespace Cludware.Repository.Infra
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        /// <summary>
        /// Obtem uma entidade pelo id.
        /// </summary>
        /// <param name="id">Id da entidade a ser encontrada.</param>
        Task<TEntity?> GetByIdAsync(int id);

        /// <summary>
        /// Ontem todas as entidades cadastradas.
        /// </summary>
        Task<List<TEntity>> GetAllAsync(TEntity filter);

        /// <summary>
        /// Adiciona um nova entidade.
        /// </summary>
        /// <param name="entity">Dados da entidade a ser adicionada.</param>
        Task<bool> AddAsync(TEntity entity);

        /// <summary>
        /// Atualiza uma entidade existente.
        /// </summary>
        /// <param name="entity">Dados da entidade a ser atualizada.</param>
        Task<bool> UpdateAsync(TEntity entity);

        /// <summary>
        /// Deleta uma entidade existente no banco de dados.
        /// </summary>
        /// <param name="id">Id da entidade a ser encontrada.</param>
        Task<bool> DeleteAsync(int id);
    }
}
