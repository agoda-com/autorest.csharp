using System;
using System.Linq;

namespace Agoda.Test.Client.Models
{
    using Newtonsoft.Json;

    public partial class Category
    {
        /// <summary>
        /// Initializes a new instance of the Category class.
        /// </summary>
        public Category() { }

        /// <summary>
        /// Initializes a new instance of the Category class.
        /// </summary>
        public Category(long? id = default(long?), string name = default(string))
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

    }
}
