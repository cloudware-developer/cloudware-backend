namespace Cludware.Repository.Infra
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository UsersRepository { get; }

        public ICompanyRepository CompaniesRepository { get; }

        public ILogAuthenticationRepository LogAuthenticationsRepository { get; }

        public UnitOfWork(
            IUserRepository userRepository,
            ICompanyRepository companiesRepository,
            ILogAuthenticationRepository logAuthenticationsRepository
        )
        {
            UsersRepository = userRepository;
            CompaniesRepository = companiesRepository;
            LogAuthenticationsRepository = logAuthenticationsRepository;
        }
    }
}
