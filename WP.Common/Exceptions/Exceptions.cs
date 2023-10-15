using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WP.Common.Exceptions
{
    public sealed class ThirdPartyServiceException : Exception
    {
        public ThirdPartyServiceException()
        {

        }

        public ThirdPartyServiceException(string message)
            : base(message)
        {

        }

        public ThirdPartyServiceException(string message,
            Exception inner)
            : base(message,
                inner)
        {

        }

        public ThirdPartyServiceException(SerializationInfo serializationInfo,
            StreamingContext context) :
            base(serializationInfo,
                context)
        {

        }
    }
}
