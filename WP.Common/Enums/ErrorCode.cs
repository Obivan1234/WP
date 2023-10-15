using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Common.Enums
{
    public enum ErrorCode
    {
        InternalServerError = 500,
        BadGateway = 502,

        InvalidRequestParameters = 1005,
        InvalidValue = 1006,
    }
}
