using Cloudware.Core.Infra.Pagination;
using Cludware.Repository.Entities;
using MediatR;

namespace Cloudware.Application.Queries.User
{
    public class ObtainUserCollectionQuery: 
        IRequest<List<UserEntity>>, 
        ISortable, 
        IPaginable, 
        IQuery<List<UserEntity>>
    {
        public int UserId { get; set; }

        public string? Name { get; set; }

        public bool Status { get; set; }

        public DateTime? EditedAt { get; set; }

        public DateTime? CreatedAt { get; set; }

        public Pagination Pagination { get; set; } = new Pagination();

        public SortField SortField { get; set; } = new SortField();

        public ObtainUserCollectionQuery() { }

        public ObtainUserCollectionQuery(int userId, string name, bool status, DateTime editedAt, DateTime createdAt)
        {
            UserId = userId;
            Name = name;
            Status = status;
            EditedAt = editedAt;
            CreatedAt = createdAt;
        }

        public ObtainUserCollectionQuery(int userId, string? name, bool status, DateTime? editedAt, DateTime? createdAt, Pagination pagination, SortField sortField)
        {
            UserId = userId;
            Name = name;
            Status = status;
            EditedAt = editedAt;
            CreatedAt = createdAt;
            Pagination = pagination;
            SortField = sortField;
        }
    }
}
