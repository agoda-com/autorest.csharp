    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using System.IO;
    using Microsoft.Rest.Serialization;
    using Agoda.RoundRobin;
    using Agoda.RoundRobin.Constants;
    using Newtonsoft.Json;
    using Agoda.Test.Client.Models;

namespace Agoda.Test.Client
{
    using Agoda.RoundRobin;
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;

    /// <summary>This is a sample server Petstore server.  You can find out more about Swagger at [http://swagger.io](http://swagger.io) or on [irc.freenode.net, #swagger](http://swagger.io/irc/).  For this sample, you can use the api key `special-key` to test the authorization filters.</summary>
    public partial interface ISwaggerPetstore
    {

    /// <summary>Gets or sets json serialization settings.</summary>
    JsonSerializerSettings SerializationSettings { get; }

    /// <summary>Gets or sets json deserialization settings.</summary>
    JsonSerializerSettings DeserializationSettings { get; }


            /// <summary>Add a new pet to the store</summary>
            /// <param name='body'>Pet object that needs to be added to the store</param>
        /// <param name='customHeaders'>The headers that will be added to request.</param>
        /// <param name='cancellationToken'>The cancellation token.</param>
        Task<Response> AddPetAsync(Pet body);

            /// <summary>Update an existing pet</summary>
            /// <param name='body'>Pet object that needs to be added to the store</param>
        /// <param name='customHeaders'>The headers that will be added to request.</param>
        /// <param name='cancellationToken'>The cancellation token.</param>
        Task<Response> UpdatePetAsync(Pet body);

            /// <summary>Finds Pets by status</summary>
            /// <remarks>Multiple status values can be provided with comma separated strings</remarks>
            /// <param name='status'>Status values that need to be considered for filter</param>
        /// <param name='customHeaders'>The headers that will be added to request.</param>
        /// <param name='cancellationToken'>The cancellation token.</param>
        Task<List<Pet>> FindPetsByStatusAsync(List<string> status);

            /// <summary>Finds Pets by tags</summary>
            /// <remarks>Multiple tags can be provided with comma separated strings. Use tag1, tag2, tag3 for testing.</remarks>
            /// <param name='tags'>Tags to filter by</param>
        /// <param name='customHeaders'>The headers that will be added to request.</param>
        /// <param name='cancellationToken'>The cancellation token.</param>
        Task<List<Pet>> FindPetsByTagsAsync(List<string> tags);

            /// <summary>Find pet by ID</summary>
            /// <remarks>Returns a single pet</remarks>
            /// <param name='petId'>ID of pet to return</param>
        /// <param name='customHeaders'>The headers that will be added to request.</param>
        /// <param name='cancellationToken'>The cancellation token.</param>
        Task<Pet> GetPetByIdAsync(long petId);

            /// <summary>Updates a pet in the store with form data</summary>
            /// <param name='petId'>ID of pet that needs to be updated</param>
            /// <param name='name'>Updated name of the pet</param>
            /// <param name='status'>Updated status of the pet</param>
        /// <param name='customHeaders'>The headers that will be added to request.</param>
        /// <param name='cancellationToken'>The cancellation token.</param>
        Task<Response> UpdatePetWithFormAsync(long petId, string name = default(string), string status = default(string));

            /// <summary>Deletes a pet</summary>
            /// <param name='petId'>Pet id to delete</param>
            /// <param name='apiKey'></param>
        /// <param name='customHeaders'>The headers that will be added to request.</param>
        /// <param name='cancellationToken'>The cancellation token.</param>
        Task<Response> DeletePetAsync(long petId);

            /// <summary>uploads an image</summary>
            /// <param name='petId'>ID of pet to update</param>
            /// <param name='additionalMetadata'>Additional data to pass to server</param>
            /// <param name='file'>file to upload</param>
        /// <param name='customHeaders'>The headers that will be added to request.</param>
        /// <param name='cancellationToken'>The cancellation token.</param>
        Task<ApiResponse> UploadFileAsync(long petId, string additionalMetadata = default(string), Stream file = default(Stream));

            /// <summary>Returns pet inventories by status</summary>
            /// <remarks>Returns a map of status codes to quantities</remarks>
        /// <param name='customHeaders'>The headers that will be added to request.</param>
        /// <param name='cancellationToken'>The cancellation token.</param>
        Task<IDictionary<string, int?>> GetInventoryAsync();

            /// <summary>Place an order for a pet</summary>
            /// <param name='body'>order placed for purchasing the pet</param>
        /// <param name='customHeaders'>The headers that will be added to request.</param>
        /// <param name='cancellationToken'>The cancellation token.</param>
        Task<Order> PlaceOrderAsync(Order body);

            /// <summary>Find purchase order by ID</summary>
            /// <remarks>For valid response try integer IDs with value &gt;= 1 and &lt;= 10. Other values will generated exceptions</remarks>
            /// <param name='orderId'>ID of pet that needs to be fetched</param>
        /// <param name='customHeaders'>The headers that will be added to request.</param>
        /// <param name='cancellationToken'>The cancellation token.</param>
        Task<Order> GetOrderByIdAsync(long orderId);

            /// <summary>Delete purchase order by ID</summary>
            /// <remarks>For valid response try integer IDs with positive integer value. Negative or non-integer values will generate API errors</remarks>
            /// <param name='orderId'>ID of the order that needs to be deleted</param>
        /// <param name='customHeaders'>The headers that will be added to request.</param>
        /// <param name='cancellationToken'>The cancellation token.</param>
        Task<Response> DeleteOrderAsync(long orderId);

            /// <summary>Create user</summary>
            /// <remarks>This can only be done by the logged in user.</remarks>
            /// <param name='body'>Created user object</param>
        /// <param name='customHeaders'>The headers that will be added to request.</param>
        /// <param name='cancellationToken'>The cancellation token.</param>
        Task<Response> CreateUserAsync(User body);

            /// <summary>Creates list of users with given input array</summary>
            /// <param name='body'>List of user object</param>
        /// <param name='customHeaders'>The headers that will be added to request.</param>
        /// <param name='cancellationToken'>The cancellation token.</param>
        Task<Response> CreateUsersWithArrayInputAsync(List<User> body);

            /// <summary>Creates list of users with given input array</summary>
            /// <param name='body'>List of user object</param>
        /// <param name='customHeaders'>The headers that will be added to request.</param>
        /// <param name='cancellationToken'>The cancellation token.</param>
        Task<Response> CreateUsersWithListInputAsync(List<User> body);

            /// <summary>Logs user into the system</summary>
            /// <param name='username'>The user name for login</param>
            /// <param name='password'>The password for login in clear text</param>
        /// <param name='customHeaders'>The headers that will be added to request.</param>
        /// <param name='cancellationToken'>The cancellation token.</param>
        Task<string> LoginUserAsync(string username, string password);

            /// <summary>Logs out current logged in user session</summary>
        /// <param name='customHeaders'>The headers that will be added to request.</param>
        /// <param name='cancellationToken'>The cancellation token.</param>
        Task<Response> LogoutUserAsync();

            /// <summary>Get user by user name</summary>
            /// <param name='username'>The name that needs to be fetched. Use user1 for testing. </param>
        /// <param name='customHeaders'>The headers that will be added to request.</param>
        /// <param name='cancellationToken'>The cancellation token.</param>
        Task<User> GetUserByNameAsync(string username);

            /// <summary>Updated user</summary>
            /// <remarks>This can only be done by the logged in user.</remarks>
            /// <param name='username'>name that need to be updated</param>
            /// <param name='body'>Updated user object</param>
        /// <param name='customHeaders'>The headers that will be added to request.</param>
        /// <param name='cancellationToken'>The cancellation token.</param>
        Task<Response> UpdateUserAsync(string username, User body);

            /// <summary>Delete user</summary>
            /// <remarks>This can only be done by the logged in user.</remarks>
            /// <param name='username'>The name that needs to be deleted</param>
        /// <param name='customHeaders'>The headers that will be added to request.</param>
        /// <param name='cancellationToken'>The cancellation token.</param>
        Task<Response> DeleteUserAsync(string username);

    }
    }
