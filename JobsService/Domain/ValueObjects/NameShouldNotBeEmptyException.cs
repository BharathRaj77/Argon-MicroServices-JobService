using System;
using System.Runtime.Serialization;

namespace Domain.ValueObjects
{
    [Serializable]
    internal class NameShouldNotBeEmptyException : Exception
    {
        public NameShouldNotBeEmptyException()
        {
        }

        public NameShouldNotBeEmptyException(string message) : base(message)
        {
        }

        public NameShouldNotBeEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NameShouldNotBeEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}