namespace Cludware.Repository.Infra
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Repositório de Usuários.
        /// </summary>
        IUserRepository UsersRepository { get; }

        /// <summary>
        /// Repositório de Empresas.
        /// </summary>
        ICompanyRepository CompaniesRepository { get; }

        /// <summary>
        /// Repositório de Logs de Autenticações no serviço.
        /// </summary>
        ILogAuthenticationRepository LogAuthenticationsRepository { get; }
    }
}
