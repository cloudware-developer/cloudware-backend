using Cloudware.Application.Commands.Company;
using Cloudware.Application.Commands.Log;
using FluentValidation;

namespace Cloudware.Application.Commands.Validations.Log
{
    public class CreateLogCommandValidation : AbstractValidator<CreateLogCommand>
    {
        public CreateLogCommandValidation()
        {
            RuleFor(x => x.LogId).GreaterThan(0).WithMessage("Informe o código do log para poder cria-lo.");
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("Informe o código do usuário para este log.");
            RuleFor(x => x.Serialized).NotEmpty().WithMessage("Informe o objeto de log.");
            RuleFor(x => x.TypeLog).IsInEnum().WithMessage("Informe o o tipo de log.");
        }
    }
}
