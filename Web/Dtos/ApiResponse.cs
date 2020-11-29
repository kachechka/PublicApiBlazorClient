using System.Net;

namespace Web.Dtos
{
    /// <summary>
    /// Data transfer object for response from REST API.
    /// </summary>
    /// <typeparam name="TData">Type of response data.</typeparam>
    public class ApiResponse<TData>
    {
        /// <summary>
        /// Gets or sets response status code.
        /// </summary>
        /// <value>Response status code.</value>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets or sets response data.
        /// </summary>
        /// <value>Response data.</value>
        public TData? Data { get; set; }

        /// <summary>
        /// Retuns has JSON parse error.
        /// </summary>
        /// <value>Has JSON parse error.</value>
        public bool HasParseError { get; }

        /// <summary>
        /// Initialize a new <see cref="ApiResponse{TData}"/> instance.
        /// </summary>
        /// <param name="statusCode">Response status code.</param>
        /// <param name="response">Response data.</param>
        public ApiResponse(HttpStatusCode statusCode, TData? response = default)
        {
            StatusCode = statusCode;
            Data = response;
        }

        /// <summary>
        /// Initialize a new <see cref="ApiResponse{TData}"/> instance.
        /// </summary>
        /// <param name="hasParseError">Has JSON parse error.</param>
        public ApiResponse(bool hasParseError)
        {
            HasParseError = hasParseError;
        }

        /// <summary>
        /// Return is status code between 200 and 229 and hasn't JSON parse error.
        /// </summary>
        /// <value>Is status code between 200 and 229 and hasn't JSON parse error.</value>
        public bool IsSuccess
        {
            get
            {
                if (HasParseError)
                {
                    return false;
                }

                var code = (int)StatusCode;

                return code >= 200 && code < 230;
            }
        }
    }
}