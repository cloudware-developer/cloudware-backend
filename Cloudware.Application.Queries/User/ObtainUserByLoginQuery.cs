using Cludware.Repository.Entities;
using MediatR;

namespace Cloudware.Application.Queries.User
{
    public class ObtainUserByLoginQuery : IRequest<UserEntity>
    {
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public ObtainUserByLoginQuery() { }

        public ObtainUserByLoginQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
