using System;
using System.Runtime.Serialization;

namespace NWAT.DB
{
    [Serializable]
    public class NWATException : Exception
    {
        public NWATException ()
        {}

        public NWATException (string message) : base(message)
        {}

        public NWATException (string message, Exception innerException) : base (message, innerException)
        {}

        protected NWATException(SerializationInfo info, StreamingContext context) : base (info, context)
        {}
    }
}
