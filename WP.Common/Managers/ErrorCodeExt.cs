using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Common.Enums;

namespace WP.Common.Managers
{
    public static class ErrorCodeExt
    {
        public static ErrorCode FromString(string errorCodeStr)
        {
            return Enum.TryParse(errorCodeStr, out ErrorCode errorCode) ? errorCode : ErrorCode.InvalidRequestParameters;
        }

        public static string ToStringCode(this ErrorCode errorCode)
        {
            return ((int)errorCode).ToString();
        }
    }
}
