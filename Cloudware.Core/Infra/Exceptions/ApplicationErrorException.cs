﻿namespace Cloudware.Core.Infra.Exceptions
{
    public class ApplicationErrorException : Exception
    {
        public ApplicationErrorException()
        {
        }

        public ApplicationErrorException(string message) : base(message)
        {
        }

        public ApplicationErrorException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
