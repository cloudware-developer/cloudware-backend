using Cloudware.Core.Infra.Enums;

namespace Cloudware.Core.Infra
{
    public abstract class BaseHandler
    {
        /// <summary>
        /// Gera tratativa de exceção com uma mensagem específica customizada pelo desenvolvedor. 
        /// </summary>
        /// <param name="message">Mensagem específica customizada pelo desenvolvedor</param>
        /// <param name="exception">Objeto de exception</param>
        public Exception ThrowException(string message, Exception exception)
        {
            if (exception.InnerException == null)
                message = $"{message} {exception.Message}";
            else
                message = $"{message} {exception.InnerException.Message}";

            return new Exception(message);
        }

        /// <summary>
        /// Gera tratativa de exceção com o objeto de exception. 
        /// </summary>
        /// <param name="exception">Objeto de exception</param>
        /// <param name="typeCommand">Tipo de comando de entrada: Create, Update, Delete, ObtainItem, ObtainCollection, ObtainCombo.</param>
        public Exception ThrowException(Exception exception, ETypeCommand typeCommand)
        {
            var message = string.Empty;

            switch (typeCommand)
            {
                case ETypeCommand.Create:
                    message = $"Erro ao inserir objeto.";
                    break;
                case ETypeCommand.Update:
                    message = $"Erro ao atualizar objeto.";
                    break;
                case ETypeCommand.Delete:
                    message = $"Erro ao deletar objeto.";
                    break;
                case ETypeCommand.ObtainItem:
                    message = $"Erro ao obter objeto.";
                    break;
                case ETypeCommand.ObtainCollection:
                    message = $"Erro ao obter lista.";
                    break;
                case ETypeCommand.ObtainCombo:
                    message = $"Erro ao obter itens da combo.";
                    break;
            }

            if (exception.InnerException == null)
                message = $"{message} {exception.Message}";
            else
                message = $"{message} {exception.InnerException.Message}";

            return new Exception(message);
        }
    }
}