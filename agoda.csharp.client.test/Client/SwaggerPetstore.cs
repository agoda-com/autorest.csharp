
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
using Agoda.Csharp.Client.Test.Models;

namespace Agoda.Csharp.Client.Test
{
    using Agoda.RoundRobin;
    using Microsoft.Rest;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;

    /// <summary>
    /// This is a sample server Petstore server.  You can find out more about
    /// Swagger at [http://swagger.io](http://swagger.io) or on
    /// [irc.freenode.net, #swagger](http://swagger.io/irc/).  For this sample,
    /// you can use the api key `special-key` to test the authorization
    /// filters.
    /// </summary>
    public partial class SwaggerPetstore : ApiBase, ISwaggerPetstore    {

        public SwaggerPetstore (IApiBaseConfig apiBaseConfig)
		: base(apiBaseConfig)
        {
        }
        /// <summary>
        /// Add a new pet to the store
        /// </summary>
        /// <param name='body'>Pet object that needs to be added to the store</param>
        /// <param name='customHeaders'>Headers that will be added to request.</param>
        /// <exception cref="HttpOperationException">Thrown when the operation returned an invalid status code</exception>
        /// <exception cref="ValidationException">Thrown when a required parameter is null</exception>
        /// <exception cref="ArgumentNullException">Thrown when a required parameter is null</exception>
        /// <return>A response object containing the response body and response headers.</return>
        public async Task<Response> AddPetAsync(Pet body)
        {
            if (body == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "body");
            }
            if (body != null)
            {
                body.Validate();
            }

            var verb = Verbs.POST;

            var queryParameters = new Dictionary<string,object>();

            var requestParameters = new RequestParameters
                                    {
                                        HttpVerb = verb,
                                        RestUrl = "/v2/pet",
                                        CustomHeaders = _customHeaders,
                                        QueryParameters = queryParameters
                                        , Body = body
                                    };

            return await InvokeNewRequest<Response>(Metrics.AddPet, requestParameters);
        }

        /// <summary>
        /// Update an existing pet
        /// </summary>
        /// <param name='body'>Pet object that needs to be added to the store</param>
        /// <param name='customHeaders'>Headers that will be added to request.</param>
        /// <exception cref="HttpOperationException">Thrown when the operation returned an invalid status code</exception>
        /// <exception cref="ValidationException">Thrown when a required parameter is null</exception>
        /// <exception cref="ArgumentNullException">Thrown when a required parameter is null</exception>
        /// <return>A response object containing the response body and response headers.</return>
        public async Task<Response> UpdatePetAsync(Pet body)
        {
            if (body == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "body");
            }
            if (body != null)
            {
                body.Validate();
            }

            var verb = Verbs.PUT;

            var queryParameters = new Dictionary<string,object>();

            var requestParameters = new RequestParameters
                                    {
                                        HttpVerb = verb,
                                        RestUrl = "/v2/pet",
                                        CustomHeaders = _customHeaders,
                                        QueryParameters = queryParameters
                                        , Body = body
                                    };

            return await InvokeNewRequest<Response>(Metrics.UpdatePet, requestParameters);
        }

        /// <summary>
        /// Finds Pets by status
        /// </summary>
        /// <remarks>
        /// Multiple status values can be provided with comma separated strings
        /// </remarks>
        /// <param name='status'>Status values that need to be considered for filter</param>
        /// <param name='customHeaders'>Headers that will be added to request.</param>
        /// <exception cref="HttpOperationException">Thrown when the operation returned an invalid status code</exception>
        /// <exception cref="SerializationException">Thrown when unable to deserialize the response</exception>
        /// <exception cref="ValidationException">Thrown when a required parameter is null</exception>
        /// <exception cref="ArgumentNullException">Thrown when a required parameter is null</exception>
        /// <return>A response object containing the response body and response headers.</return>
        public async Task<List<Pet>> FindPetsByStatusAsync(List<string> status)
        {
            if (status == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "status");
            }

            var verb = Verbs.GET;

            var queryParameters = new Dictionary<string,object>();
            if (status != null){
                if (status.Count == 0)
                {
                    queryParameters.Add("status",string.Empty);
                }
                else
                {
                    foreach (var _item in status)
                    {
                        queryParameters.Add("status",_item.ToString() ?? string.Empty);
                    }
                }
            }

            var requestParameters = new RequestParameters
                                    {
                                        HttpVerb = verb,
                                        RestUrl = "/v2/pet/findByStatus",
                                        CustomHeaders = _customHeaders,
                                        QueryParameters = queryParameters
                                    };

            return await InvokeNewRequest<List<Pet>>(Metrics.FindPetsByStatus, requestParameters);
        }

        /// <summary>
        /// Finds Pets by tags
        /// </summary>
        /// <remarks>
        /// Multiple tags can be provided with comma separated strings. Use tag1, tag2,
        /// tag3 for testing.
        /// </remarks>
        /// <param name='tags'>Tags to filter by</param>
        /// <param name='customHeaders'>Headers that will be added to request.</param>
        /// <exception cref="HttpOperationException">Thrown when the operation returned an invalid status code</exception>
        /// <exception cref="SerializationException">Thrown when unable to deserialize the response</exception>
        /// <exception cref="ValidationException">Thrown when a required parameter is null</exception>
        /// <exception cref="ArgumentNullException">Thrown when a required parameter is null</exception>
        /// <return>A response object containing the response body and response headers.</return>
        [Obsolete()]
        public async Task<List<Pet>> FindPetsByTagsAsync(List<string> tags)
        {
            if (tags == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "tags");
            }

            var verb = Verbs.GET;

            var queryParameters = new Dictionary<string,object>();
            if (tags != null){
                if (tags.Count == 0)
                {
                    queryParameters.Add("tags",string.Empty);
                }
                else
                {
                    foreach (var _item in tags)
                    {
                        queryParameters.Add("tags",_item.ToString() ?? string.Empty);
                    }
                }
            }

            var requestParameters = new RequestParameters
                                    {
                                        HttpVerb = verb,
                                        RestUrl = "/v2/pet/findByTags",
                                        CustomHeaders = _customHeaders,
                                        QueryParameters = queryParameters
                                    };

            return await InvokeNewRequest<List<Pet>>(Metrics.FindPetsByTags, requestParameters);
        }

        /// <summary>
        /// Find pet by ID
        /// </summary>
        /// <remarks>
        /// Returns a single pet
        /// </remarks>
        /// <param name='petId'>ID of pet to return</param>
        /// <param name='customHeaders'>Headers that will be added to request.</param>
        /// <exception cref="HttpOperationException">Thrown when the operation returned an invalid status code</exception>
        /// <exception cref="SerializationException">Thrown when unable to deserialize the response</exception>
        /// <return>A response object containing the response body and response headers.</return>
        public async Task<Pet> GetPetByIdAsync(long petId)
        {

            var verb = Verbs.GET;

            var queryParameters = new Dictionary<string,object>();
            queryParameters.Add("petId",SafeJsonConvert.SerializeObject(petId, SerializationSettings).Trim('"'));

            var requestParameters = new RequestParameters
                                    {
                                        HttpVerb = verb,
                                        RestUrl = "/v2/pet/{petId}",
                                        CustomHeaders = _customHeaders,
                                        QueryParameters = queryParameters
                                    };

            return await InvokeNewRequest<Pet>(Metrics.GetPetById, requestParameters);
        }

        /// <summary>
        /// Updates a pet in the store with form data
        /// </summary>
        /// <param name='petId'>ID of pet that needs to be updated</param>
        /// <param name='name'>Updated name of the pet</param>
        /// <param name='status'>Updated status of the pet</param>
        /// <param name='customHeaders'>Headers that will be added to request.</param>
        /// <exception cref="HttpOperationException">Thrown when the operation returned an invalid status code</exception>
        /// <return>A response object containing the response body and response headers.</return>
        public async Task<Response> UpdatePetWithFormAsync(long petId, string name = default(string), string status = default(string))
        {

            var verb = Verbs.POST;

            var queryParameters = new Dictionary<string,object>();
            queryParameters.Add("petId",SafeJsonConvert.SerializeObject(petId, SerializationSettings).Trim('"'));

            var requestParameters = new RequestParameters
                                    {
                                        HttpVerb = verb,
                                        RestUrl = "/v2/pet/{petId}",
                                        CustomHeaders = _customHeaders,
                                        QueryParameters = queryParameters
                                    };

            return await InvokeNewRequest<Response>(Metrics.UpdatePetWithForm, requestParameters);
        }

        /// <summary>
        /// Deletes a pet
        /// </summary>
        /// <param name='petId'>Pet id to delete</param>
        /// <param name='apiKey'></param>
        /// <param name='customHeaders'>Headers that will be added to request.</param>
        /// <exception cref="HttpOperationException">Thrown when the operation returned an invalid status code</exception>
        /// <return>A response object containing the response body and response headers.</return>
        public async Task<Response> DeletePetAsync(long petId)
        {

            var verb = Verbs.DELETE;

            var queryParameters = new Dictionary<string,object>();
            queryParameters.Add("petId",SafeJsonConvert.SerializeObject(petId, SerializationSettings).Trim('"'));

            var requestParameters = new RequestParameters
                                    {
                                        HttpVerb = verb,
                                        RestUrl = "/v2/pet/{petId}",
                                        CustomHeaders = _customHeaders,
                                        QueryParameters = queryParameters
                                    };

            return await InvokeNewRequest<Response>(Metrics.DeletePet, requestParameters);
        }

        /// <summary>
        /// uploads an image
        /// </summary>
        /// <param name='petId'>ID of pet to update</param>
        /// <param name='additionalMetadata'>Additional data to pass to server</param>
        /// <param name='file'>file to upload</param>
        /// <param name='customHeaders'>Headers that will be added to request.</param>
        /// <exception cref="HttpOperationException">Thrown when the operation returned an invalid status code</exception>
        /// <exception cref="SerializationException">Thrown when unable to deserialize the response</exception>
        /// <return>A response object containing the response body and response headers.</return>
        public async Task<ApiResponse> UploadFileAsync(long petId, string additionalMetadata = default(string), Stream file = default(Stream))
        {

            var verb = Verbs.POST;

            var queryParameters = new Dictionary<string,object>();
            queryParameters.Add("petId",SafeJsonConvert.SerializeObject(petId, SerializationSettings).Trim('"'));

            var requestParameters = new RequestParameters
                                    {
                                        HttpVerb = verb,
                                        RestUrl = "/v2/pet/{petId}/uploadImage",
                                        CustomHeaders = _customHeaders,
                                        QueryParameters = queryParameters
                                    };

            return await InvokeNewRequest<ApiResponse>(Metrics.UploadFile, requestParameters);
        }

        /// <summary>
        /// Returns pet inventories by status
        /// </summary>
        /// <remarks>
        /// Returns a map of status codes to quantities
        /// </remarks>
        /// <param name='customHeaders'>Headers that will be added to request.</param>
        /// <exception cref="HttpOperationException">Thrown when the operation returned an invalid status code</exception>
        /// <exception cref="SerializationException">Thrown when unable to deserialize the response</exception>
        /// <return>A response object containing the response body and response headers.</return>
        public async Task<IDictionary<string, int?>> GetInventoryAsync()
        {

            var verb = Verbs.GET;

            var queryParameters = new Dictionary<string,object>();

            var requestParameters = new RequestParameters
                                    {
                                        HttpVerb = verb,
                                        RestUrl = "/v2/store/inventory",
                                        CustomHeaders = _customHeaders,
                                        QueryParameters = queryParameters
                                    };

            return await InvokeNewRequest<IDictionary<string, int?>>(Metrics.GetInventory, requestParameters);
        }

        /// <summary>
        /// Place an order for a pet
        /// </summary>
        /// <param name='body'>order placed for purchasing the pet</param>
        /// <param name='customHeaders'>Headers that will be added to request.</param>
        /// <exception cref="HttpOperationException">Thrown when the operation returned an invalid status code</exception>
        /// <exception cref="SerializationException">Thrown when unable to deserialize the response</exception>
        /// <exception cref="ValidationException">Thrown when a required parameter is null</exception>
        /// <exception cref="ArgumentNullException">Thrown when a required parameter is null</exception>
        /// <return>A response object containing the response body and response headers.</return>
        public async Task<Order> PlaceOrderAsync(Order body)
        {
            if (body == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "body");
            }

            var verb = Verbs.POST;

            var queryParameters = new Dictionary<string,object>();

            var requestParameters = new RequestParameters
                                    {
                                        HttpVerb = verb,
                                        RestUrl = "/v2/store/order",
                                        CustomHeaders = _customHeaders,
                                        QueryParameters = queryParameters
                                        , Body = body
                                    };

            return await InvokeNewRequest<Order>(Metrics.PlaceOrder, requestParameters);
        }

        /// <summary>
        /// Find purchase order by ID
        /// </summary>
        /// <remarks>
        /// For valid response try integer IDs with value &gt;= 1 and &lt;= 10. Other
        /// values will generated exceptions
        /// </remarks>
        /// <param name='orderId'>ID of pet that needs to be fetched</param>
        /// <param name='customHeaders'>Headers that will be added to request.</param>
        /// <exception cref="HttpOperationException">Thrown when the operation returned an invalid status code</exception>
        /// <exception cref="SerializationException">Thrown when unable to deserialize the response</exception>
        /// <return>A response object containing the response body and response headers.</return>
        public async Task<Order> GetOrderByIdAsync(long orderId)
        {
            if (orderId > 10)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "orderId", 10);
            }
            if (orderId < 1)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "orderId", 1);
            }

            var verb = Verbs.GET;

            var queryParameters = new Dictionary<string,object>();
            queryParameters.Add("orderId",SafeJsonConvert.SerializeObject(orderId, SerializationSettings).Trim('"'));

            var requestParameters = new RequestParameters
                                    {
                                        HttpVerb = verb,
                                        RestUrl = "/v2/store/order/{orderId}",
                                        CustomHeaders = _customHeaders,
                                        QueryParameters = queryParameters
                                    };

            return await InvokeNewRequest<Order>(Metrics.GetOrderById, requestParameters);
        }

        /// <summary>
        /// Delete purchase order by ID
        /// </summary>
        /// <remarks>
        /// For valid response try integer IDs with positive integer value. Negative or
        /// non-integer values will generate API errors
        /// </remarks>
        /// <param name='orderId'>ID of the order that needs to be deleted</param>
        /// <param name='customHeaders'>Headers that will be added to request.</param>
        /// <exception cref="HttpOperationException">Thrown when the operation returned an invalid status code</exception>
        /// <return>A response object containing the response body and response headers.</return>
        public async Task<Response> DeleteOrderAsync(long orderId)
        {
            if (orderId < 1)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "orderId", 1);
            }

            var verb = Verbs.DELETE;

            var queryParameters = new Dictionary<string,object>();
            queryParameters.Add("orderId",SafeJsonConvert.SerializeObject(orderId, SerializationSettings).Trim('"'));

            var requestParameters = new RequestParameters
                                    {
                                        HttpVerb = verb,
                                        RestUrl = "/v2/store/order/{orderId}",
                                        CustomHeaders = _customHeaders,
                                        QueryParameters = queryParameters
                                    };

            return await InvokeNewRequest<Response>(Metrics.DeleteOrder, requestParameters);
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <remarks>
        /// This can only be done by the logged in user.
        /// </remarks>
        /// <param name='body'>Created user object</param>
        /// <param name='customHeaders'>Headers that will be added to request.</param>
        /// <exception cref="HttpOperationException">Thrown when the operation returned an invalid status code</exception>
        /// <exception cref="ValidationException">Thrown when a required parameter is null</exception>
        /// <exception cref="ArgumentNullException">Thrown when a required parameter is null</exception>
        /// <return>A response object containing the response body and response headers.</return>
        public async Task<Response> CreateUserAsync(User body)
        {
            if (body == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "body");
            }

            var verb = Verbs.POST;

            var queryParameters = new Dictionary<string,object>();

            var requestParameters = new RequestParameters
                                    {
                                        HttpVerb = verb,
                                        RestUrl = "/v2/user",
                                        CustomHeaders = _customHeaders,
                                        QueryParameters = queryParameters
                                        , Body = body
                                    };

            return await InvokeNewRequest<Response>(Metrics.CreateUser, requestParameters);
        }

        /// <summary>
        /// Creates list of users with given input array
        /// </summary>
        /// <param name='body'>List of user object</param>
        /// <param name='customHeaders'>Headers that will be added to request.</param>
        /// <exception cref="HttpOperationException">Thrown when the operation returned an invalid status code</exception>
        /// <exception cref="ValidationException">Thrown when a required parameter is null</exception>
        /// <exception cref="ArgumentNullException">Thrown when a required parameter is null</exception>
        /// <return>A response object containing the response body and response headers.</return>
        public async Task<Response> CreateUsersWithArrayInputAsync(List<User> body)
        {
            if (body == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "body");
            }

            var verb = Verbs.POST;

            var queryParameters = new Dictionary<string,object>();

            var requestParameters = new RequestParameters
                                    {
                                        HttpVerb = verb,
                                        RestUrl = "/v2/user/createWithArray",
                                        CustomHeaders = _customHeaders,
                                        QueryParameters = queryParameters
                                        , Body = body
                                    };

            return await InvokeNewRequest<Response>(Metrics.CreateUsersWithArrayInput, requestParameters);
        }

        /// <summary>
        /// Creates list of users with given input array
        /// </summary>
        /// <param name='body'>List of user object</param>
        /// <param name='customHeaders'>Headers that will be added to request.</param>
        /// <exception cref="HttpOperationException">Thrown when the operation returned an invalid status code</exception>
        /// <exception cref="ValidationException">Thrown when a required parameter is null</exception>
        /// <exception cref="ArgumentNullException">Thrown when a required parameter is null</exception>
        /// <return>A response object containing the response body and response headers.</return>
        public async Task<Response> CreateUsersWithListInputAsync(List<User> body)
        {
            if (body == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "body");
            }

            var verb = Verbs.POST;

            var queryParameters = new Dictionary<string,object>();

            var requestParameters = new RequestParameters
                                    {
                                        HttpVerb = verb,
                                        RestUrl = "/v2/user/createWithList",
                                        CustomHeaders = _customHeaders,
                                        QueryParameters = queryParameters
                                        , Body = body
                                    };

            return await InvokeNewRequest<Response>(Metrics.CreateUsersWithListInput, requestParameters);
        }

        /// <summary>
        /// Logs user into the system
        /// </summary>
        /// <param name='username'>The user name for login</param>
        /// <param name='password'>The password for login in clear text</param>
        /// <param name='customHeaders'>Headers that will be added to request.</param>
        /// <exception cref="HttpOperationException">Thrown when the operation returned an invalid status code</exception>
        /// <exception cref="SerializationException">Thrown when unable to deserialize the response</exception>
        /// <exception cref="ValidationException">Thrown when a required parameter is null</exception>
        /// <exception cref="ArgumentNullException">Thrown when a required parameter is null</exception>
        /// <return>A response object containing the response body and response headers.</return>
        public async Task<string> LoginUserAsync(string username, string password)
        {
            if (username == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "username");
            }
            if (password == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "password");
            }

            var verb = Verbs.GET;

            var queryParameters = new Dictionary<string,object>();
            if (username != null)queryParameters.Add("username",username);
            if (password != null)queryParameters.Add("password",password);

            var requestParameters = new RequestParameters
                                    {
                                        HttpVerb = verb,
                                        RestUrl = "/v2/user/login",
                                        CustomHeaders = _customHeaders,
                                        QueryParameters = queryParameters
                                    };

            return await InvokeNewRequest<string>(Metrics.LoginUser, requestParameters);
        }

        /// <summary>
        /// Logs out current logged in user session
        /// </summary>
        /// <param name='customHeaders'>Headers that will be added to request.</param>
        /// <exception cref="HttpOperationException">Thrown when the operation returned an invalid status code</exception>
        /// <return>A response object containing the response body and response headers.</return>
        public async Task<Response> LogoutUserAsync()
        {

            var verb = Verbs.GET;

            var queryParameters = new Dictionary<string,object>();

            var requestParameters = new RequestParameters
                                    {
                                        HttpVerb = verb,
                                        RestUrl = "/v2/user/logout",
                                        CustomHeaders = _customHeaders,
                                        QueryParameters = queryParameters
                                    };

            return await InvokeNewRequest<Response>(Metrics.LogoutUser, requestParameters);
        }

        /// <summary>
        /// Get user by user name
        /// </summary>
        /// <param name='username'>The name that needs to be fetched. Use user1 for testing. </param>
        /// <param name='customHeaders'>Headers that will be added to request.</param>
        /// <exception cref="HttpOperationException">Thrown when the operation returned an invalid status code</exception>
        /// <exception cref="SerializationException">Thrown when unable to deserialize the response</exception>
        /// <exception cref="ValidationException">Thrown when a required parameter is null</exception>
        /// <exception cref="ArgumentNullException">Thrown when a required parameter is null</exception>
        /// <return>A response object containing the response body and response headers.</return>
        public async Task<User> GetUserByNameAsync(string username)
        {
            if (username == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "username");
            }

            var verb = Verbs.GET;

            var queryParameters = new Dictionary<string,object>();
            queryParameters.Add("username",username);

            var requestParameters = new RequestParameters
                                    {
                                        HttpVerb = verb,
                                        RestUrl = "/v2/user/{username}",
                                        CustomHeaders = _customHeaders,
                                        QueryParameters = queryParameters
                                    };

            return await InvokeNewRequest<User>(Metrics.GetUserByName, requestParameters);
        }

        /// <summary>
        /// Updated user
        /// </summary>
        /// <remarks>
        /// This can only be done by the logged in user.
        /// </remarks>
        /// <param name='username'>name that need to be updated</param>
        /// <param name='body'>Updated user object</param>
        /// <param name='customHeaders'>Headers that will be added to request.</param>
        /// <exception cref="HttpOperationException">Thrown when the operation returned an invalid status code</exception>
        /// <exception cref="ValidationException">Thrown when a required parameter is null</exception>
        /// <exception cref="ArgumentNullException">Thrown when a required parameter is null</exception>
        /// <return>A response object containing the response body and response headers.</return>
        public async Task<Response> UpdateUserAsync(string username, User body)
        {
            if (username == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "username");
            }
            if (body == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "body");
            }

            var verb = Verbs.PUT;

            var queryParameters = new Dictionary<string,object>();
            queryParameters.Add("username",username);

            var requestParameters = new RequestParameters
                                    {
                                        HttpVerb = verb,
                                        RestUrl = "/v2/user/{username}",
                                        CustomHeaders = _customHeaders,
                                        QueryParameters = queryParameters
                                        , Body = body
                                    };

            return await InvokeNewRequest<Response>(Metrics.UpdateUser, requestParameters);
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <remarks>
        /// This can only be done by the logged in user.
        /// </remarks>
        /// <param name='username'>The name that needs to be deleted</param>
        /// <param name='customHeaders'>Headers that will be added to request.</param>
        /// <exception cref="HttpOperationException">Thrown when the operation returned an invalid status code</exception>
        /// <exception cref="ValidationException">Thrown when a required parameter is null</exception>
        /// <exception cref="ArgumentNullException">Thrown when a required parameter is null</exception>
        /// <return>A response object containing the response body and response headers.</return>
        public async Task<Response> DeleteUserAsync(string username)
        {
            if (username == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "username");
            }

            var verb = Verbs.DELETE;

            var queryParameters = new Dictionary<string,object>();
            queryParameters.Add("username",username);

            var requestParameters = new RequestParameters
                                    {
                                        HttpVerb = verb,
                                        RestUrl = "/v2/user/{username}",
                                        CustomHeaders = _customHeaders,
                                        QueryParameters = queryParameters
                                    };

            return await InvokeNewRequest<Response>(Metrics.DeleteUser, requestParameters);
        }

    }
}
