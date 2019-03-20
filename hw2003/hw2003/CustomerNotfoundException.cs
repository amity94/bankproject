using System;
using System.Runtime.Serialization;

namespace hw2003
{
    [Serializable]
    internal class CustomerNotfoundException : Exception
    {
        public CustomerNotfoundException()
        {
        }

        public CustomerNotfoundException(string message) : base(message)
        {
        }

        public CustomerNotfoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomerNotfoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}