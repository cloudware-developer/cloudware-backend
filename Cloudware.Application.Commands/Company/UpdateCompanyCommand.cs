using MediatR;

namespace Cloudware.Application.Commands.Company
{
    public class UpdateCompanyCommand : IRequest<bool>
    {
        public int CompanyId { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public bool Status { get; set; }

        public DateTime? EditedAt { get; set; }

        public DateTime? CreatedAt { get; set; }

        public UpdateCompanyCommand()
        {
        }

        public UpdateCompanyCommand(int companyId, string? name, string? email, bool status, DateTime? editedAt, DateTime? createdAt)
        {
            CompanyId = CompanyId;
            Name = name;
            Email = email;
            Status = status;
            EditedAt = editedAt;
            CreatedAt = createdAt;
        }
    }
}
