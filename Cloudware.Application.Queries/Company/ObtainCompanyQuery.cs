using Cludware.Repository.Entities;
using MediatR;

namespace Cloudware.Application.Queries.Company
{
    public class ObtainCompanyQuery : IRequest<CompanyEntity>
    {
        public int CompanyId { get; set; }

        public ObtainCompanyQuery() { }

        public ObtainCompanyQuery(int companyId)
        {
            CompanyId = companyId;
        }
    }
}
