using Cloudware.Core.Infra.Pagination;
using Cludware.Repository.Entities;
using MediatR;

namespace Cloudware.Application.Queries.Company
{
    public class ObtainCompanyCollectionQuery: 
        IRequest<List<CompanyEntity>>, 
        ISortable, 
        IPaginable, 
        IQuery<List<CompanyEntity>>
    {
        public int CompanyId { get; set; }

        public string? Name { get; set; }

        public bool Status { get; set; }

        public DateTime? EditedAt { get; set; }

        public DateTime? CreatedAt { get; set; }

        public Pagination Pagination { get; set; } = new Pagination();

        public SortField SortField { get; set; } = new SortField();

        public ObtainCompanyCollectionQuery() { }

        public ObtainCompanyCollectionQuery(int companyId, string name, bool status, DateTime editedAt, DateTime createdAt)
        {
            CompanyId = companyId;
            Name = name;
            Status = status;
            EditedAt = editedAt;
            CreatedAt = createdAt;
        }

        public ObtainCompanyCollectionQuery(int companyId, string? name, bool status, DateTime? editedAt, DateTime? createdAt, Pagination pagination, SortField sortField)
        {
            CompanyId = companyId;
            Name = name;
            Status = status;
            EditedAt = editedAt;
            CreatedAt = createdAt;
            Pagination = pagination;
            SortField = sortField;
        }
    }
}
