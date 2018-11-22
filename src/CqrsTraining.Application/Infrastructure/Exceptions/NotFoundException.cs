using System;

namespace CqrsTraining.Application.Infrastructure.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message)
            : base(message)
        {
        }
    }
}
