﻿namespace net6_api_compras.Domain.Validations
{
    internal class DomainValidationException : Exception
    {
        public DomainValidationException(string error) : base(error) { }

        public static void When(bool hasError, string message)
        {
            if (hasError) throw new DomainValidationException(message);
        }
    }
}