using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Common.Enums;
using WP.Common.Models;

namespace WP.Common.Managers
{
    public static class ResponseObjectExtension
    {
        public static ResponseObject<T> GetResponseObject<T>(this T obj) where T : class
        {
            if (obj == null)
            {
                return new ResponseHandler()
                    .SetErrorCode(new ResponseObject<T>(), ErrorCode.InvalidValue);
            }

            return new ResponseObject<T>()
            {
                Data = new[] { obj }
            };
        }
        public static ResponseObject<IdDto<TId>> GetIdResponse<TId>(this TId id)
        {
            return new ResponseObject<IdDto<TId>>
            {
                Data = new[] { new IdDto<TId> { Id = id } }
            };
        }
    }
}
