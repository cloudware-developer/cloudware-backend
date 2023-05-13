using Cludware.Repository.Entities;
using MediatR;

namespace Cloudware.Application.Queries.User
{
    public class ObtainUserQuery : IRequest<UserEntity>
    {
        public int UserId { get; set; }

        public ObtainUserQuery() { }

        public ObtainUserQuery(int userId)
        {
            UserId = userId;
        }
    }
}
