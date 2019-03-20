using System;
using System.Runtime.Serialization;

namespace hw2003
{
    [Serializable]
    internal class CustomerAlreadyEsxistsException : Exception
    {
        public CustomerAlreadyEsxistsException()
        {
        }

        public CustomerAlreadyEsxistsException(string message) : base(message)
        {
        }

        public CustomerAlreadyEsxistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomerAlreadyEsxistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}