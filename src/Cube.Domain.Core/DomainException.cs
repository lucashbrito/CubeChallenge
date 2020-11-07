using System;

namespace Cube.Domain.Core
{
    public class DomainException : Exception
    {
        public DomainException()
        {

        }

        public DomainException(string message) : base(message)
        {

        }

        public DomainException(string message, Exception innException) : base(message, innException)
        {

        }
    }
}
