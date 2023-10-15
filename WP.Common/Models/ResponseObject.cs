using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WP.Common.Models
{
    public class ResponseObject<TDto> where TDto : class
    {
        [JsonPropertyName("data")] public IEnumerable<TDto> Data { get; set; } = null;

        [JsonPropertyName("errors")]
        public List<WPError> Errors { get; set; } = null;

        public ResponseObject<TDto> AddErrorCode(WPError error)
        {
            Errors ??= new List<WPError>();
            Errors.Add(error);
            return this;
        }

        public bool HasErrors()
        {
            return Errors != null && Errors.Any();
        }
    }
}
