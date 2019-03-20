using System;
using System.Runtime.Serialization;

namespace hw2003
{
    [Serializable]
    internal class AccountNotFountException : Exception
    {
        public AccountNotFountException()
        {
        }

        public AccountNotFountException(string message) : base(message)
        {
        }

        public AccountNotFountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AccountNotFountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}