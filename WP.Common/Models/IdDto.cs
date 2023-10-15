using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Common.Models
{
    public class IdDto<TId>
    {
        public TId Id { get; set; }

        public IdDto(TId id)
        {
            Id = id;
        }

        public IdDto()
        {

        }
    }
}
