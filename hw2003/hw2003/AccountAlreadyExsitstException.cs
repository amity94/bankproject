using System;
using System.Runtime.Serialization;

namespace hw2003
{
    [Serializable]
    internal class AccountAlreadyExsitstException : Exception
    {
        public AccountAlreadyExsitstException()
        {
        }

        public AccountAlreadyExsitstException(string message) : base(message)
        {
        }

        public AccountAlreadyExsitstException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AccountAlreadyExsitstException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}