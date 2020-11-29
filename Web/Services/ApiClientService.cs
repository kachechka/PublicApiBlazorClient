using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Web.Dtos;
using Web.Helpers;

namespace Web.Services
{
    /// <summary>
    /// API client service.
    /// </summary>
    public class ApiClientService
    {
        /// <summary>
        /// <see cref="HttpClient"/> name.
        /// </summary>
        public static readonly string ClientName = "JsonPlaceholder";

        private readonly HttpClient _client;

        /// <summary>
        /// Initalize a new <see cref="ApiClientService"/> instance.
        /// </summary>
        /// <param name="clientFactory"><see cref="IHttpClientFactory"/> from which the <see cref="HttpClient"/> will be getted by name <see cref="ClientName"/>.</param>
        public ApiClientService([NotNull] IHttpClientFactory? clientFactory)
        {
            ThrowHelper.ThrowIfIsNull(clientFactory, nameof(clientFactory));

            _client = clientFactory.CreateClient(ClientName);
        }

        /// <summary>
        /// Return response from API by GET method and <paramref name="uri"/>.
        /// </summary>
        /// <typeparam name="TResponse">Type of response data.</typeparam>
        /// <param name="uri">URI to send request.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>API response.</returns>
        public async Task<ApiResponse<TResponse>> GetAsync<TResponse>(
            [NotNull] string? uri,
            CancellationToken cancellationToken = default)
        {
            ThrowHelper.ThrowIfIsNullOrWhiteSpace(uri);

            try
            {
                var responseMessage = await _client.GetAsync(uri, cancellationToken);

                if (!responseMessage.IsSuccessStatusCode)
                {
                    return new ApiResponse<TResponse>(responseMessage.StatusCode);
                }

                var json = await responseMessage.Content.ReadAsStringAsync();
                
                var data = JsonSerializer.Deserialize<TResponse>(json);

                return new ApiResponse<TResponse>(responseMessage.StatusCode, data);
            }
            catch (JsonException)
            {
                return new ApiResponse<TResponse>(hasParseError: true);
            }
        }

    }
}