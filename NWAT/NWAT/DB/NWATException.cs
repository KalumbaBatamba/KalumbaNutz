using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
