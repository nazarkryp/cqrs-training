using System;
using System.Collections.Generic;

namespace CqrsTraining.Application.Infrastructure.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
            : base("One or more validation failures have occurred.")
        {
            Failures = new Dictionary<string, string[]>();
        }

        public IDictionary<string, string[]> Failures { get; }
    }
}
