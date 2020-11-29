using System;
using System.Net;
using Web.Dtos;

namespace Web.Helpers
{
    /// <summary>
    /// Helper for <see cref="ApiResponse{TData}"/>.
    /// </summary>
    public class ApiResponseHelper
    {
        /// <summary>
        /// Not success API response handler.
        /// </summary>
        /// <typeparam name="TResponse">Type of API response data.</typeparam>
        /// <param name="response">API response.</param>
        public static void HandleNotSuccessApiResponse<TResponse>(ApiResponse<TResponse> response)
        {
            Console.Error.WriteLine($"Api responsed with code {response.StatusCode}");

            switch (response.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    // TODO redirecto to not found page
                    break;
                default:
                    break;
            }
        }
    }
}