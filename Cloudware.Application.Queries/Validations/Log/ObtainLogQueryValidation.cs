using Cloudware.Application.Queries.Log;
using FluentValidation;

namespace Cloudware.Application.Queries.Validations.Log
{
    public class ObtainLogQueryValidation : AbstractValidator<ObtainLogQuery>
    {
        public ObtainLogQueryValidation()
        {
            RuleFor(x => x.LogId).GreaterThan(0).WithMessage("Informe o código do log.");
        }
    }
}
