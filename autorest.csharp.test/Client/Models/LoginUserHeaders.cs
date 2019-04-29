using System;
using System.Linq;

namespace Agoda.Test.Client.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines headers for loginUser operation.
    /// </summary>
    public partial class LoginUserHeaders
    {
        /// <summary>
        /// Initializes a new instance of the LoginUserHeaders class.
        /// </summary>
        public LoginUserHeaders() { }

        /// <summary>
        /// Initializes a new instance of the LoginUserHeaders class.
        /// </summary>
        /// <param name="xRateLimit">calls per hour allowed by the user</param>
        /// <param name="xExpiresAfter">date in UTC when token expires</param>
        public LoginUserHeaders(int? xRateLimit = default(int?), DateTime? xExpiresAfter = default(DateTime?))
        {
            XRateLimit = xRateLimit;
            XExpiresAfter = xExpiresAfter;
        }

        /// <summary>
        /// Gets or sets calls per hour allowed by the user
        /// </summary>
        [JsonProperty(PropertyName = "X-Rate-Limit")]
        public int? XRateLimit { get; set; }

        /// <summary>
        /// Gets or sets date in UTC when token expires
        /// </summary>
        [JsonProperty(PropertyName = "X-Expires-After")]
        public DateTime? XExpiresAfter { get; set; }

    }
}
