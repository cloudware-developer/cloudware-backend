using MediatR;

namespace Cloudware.Application.Commands.Company
{
    public class DeleteCompanyCommand : IRequest<bool>
    {
        public int CompanyId { get; set; }

        public DeleteCompanyCommand() { }

        public DeleteCompanyCommand(int companyId)
        {
            CompanyId = companyId;
        }
    }
}
