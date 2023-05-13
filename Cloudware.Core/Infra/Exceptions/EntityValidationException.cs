using FluentValidation.Results;

namespace Cloudware.Core.Infra.Exceptions
{
    public class EntityValidationException : Exception
    {
        public EntityValidationException()
        {
        }

        public EntityValidationException(string message) : base(message)
        {
        }

        public EntityValidationException(string message, Exception inner) : base(message, inner)
        {
        }

        public EntityValidationException(List<ValidationFailure> errors)
        {

        }

        public EntityValidationException(string message, List<ValidationFailure> errors)
        {
        }
    }
}
