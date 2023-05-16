using Cloudware.Application.Commands.Company;
using Cloudware.Application.Commands.Log;
using FluentValidation;

namespace Cloudware.Application.Commands.Validations.Log
{
    public class DeleteLogCommandValidation : AbstractValidator<DeleteLogCommand>
    {
        public DeleteLogCommandValidation()
        {
            RuleFor(x => x.LogId).GreaterThan(0).WithMessage("Informe o código do usuário para poder apaga-lo.");
        }
    }
}
