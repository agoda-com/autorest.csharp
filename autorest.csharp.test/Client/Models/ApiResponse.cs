using System;
using System.Linq;

namespace Agoda.Test.Client.Models
{
    using Newtonsoft.Json;

    public partial class ApiResponse
    {
        /// <summary>
        /// Initializes a new instance of the ApiResponse class.
        /// </summary>
        public ApiResponse() { }

        /// <summary>
        /// Initializes a new instance of the ApiResponse class.
        /// </summary>
        public ApiResponse(int? code = default(int?), string type = default(string), string message = default(string))
        {
            Code = code;
            Type = type;
            Message = message;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public int? Code { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

    }
}
