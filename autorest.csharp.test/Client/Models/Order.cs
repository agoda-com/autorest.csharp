using System;
using System.Linq;

namespace Agoda.Test.Client.Models
{
    using Newtonsoft.Json;

    public partial class Order
    {
        /// <summary>
        /// Initializes a new instance of the Order class.
        /// </summary>
        public Order() { }

        /// <summary>
        /// Initializes a new instance of the Order class.
        /// </summary>
        /// <param name="status">Order Status. Possible values include:
        /// 'placed', 'approved', 'delivered'</param>
        public Order(long? id = default(long?), long? petId = default(long?), int? quantity = default(int?), DateTime? shipDate = default(DateTime?), string status = default(string), bool? complete = default(bool?))
        {
            Id = id;
            PetId = petId;
            Quantity = quantity;
            ShipDate = shipDate;
            Status = status;
            Complete = complete;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "petId")]
        public long? PetId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "quantity")]
        public int? Quantity { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "shipDate")]
        public DateTime? ShipDate { get; set; }

        /// <summary>
        /// Gets or sets order Status. Possible values include: 'placed',
        /// 'approved', 'delivered'
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "complete")]
        public bool? Complete { get; set; }

    }
}
