using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Helpers;
using Web.Models;
using Web.Services;

namespace Web.Extensions
{
    public static class ApiClientExcensions
    {
        /// <summary>
        /// Load <see cref="IEnumerable{User}"/> by path '/users'.
        /// </summary>
        /// <param name="apiClient"></param>
        /// <returns>Loaded users.</returns>
        public static Task<IEnumerable<User>?> GetUsersAsync(this ApiClientService apiClient)
        {
            return GetAsync<IEnumerable<User>>(apiClient, "/users");
        }

        /// <summary>
        /// Load <see cref="IEnumerable{Album}"/> by path '/albums'.
        /// </summary>
        /// <param name="apiClient"></param>
        /// <returns>Loaded albums.</returns>
        public static Task<IEnumerable<Album>?> GetAlbumsAsync(this ApiClientService apiClient)
        {
            return GetAsync<IEnumerable<Album>>(apiClient, "/albums");
        }

        /// <summary>
        /// Load <see cref="Album"/> by path '/albums/{id}'.
        /// </summary>
        /// <param name="apiClient"></param>
        /// <param name="id">Album id.</param>
        /// <returns>Loaded album.</returns>
        public static Task<Album?> GetAlbumByIdAsync(
            this ApiClientService apiClient,
            int id)
        {
            return GetAsync<Album>(apiClient, $"/albums/{id}");
        }

        /// <summary>
        /// Load <see cref="IEnumerable{Photo}"/> by path '/albums/{id}/photos'.
        /// </summary>
        /// <param name="apiClient"></param>
        /// <param name="albumId">Album id.</param>
        /// <returns>Loaded photos.</returns>
        public static Task<IEnumerable<Photo>?> GetPhotosByAlbumIdAsync(
            this ApiClientService apiClient,
            int albumId)
        {
            return GetAsync<IEnumerable<Photo>>(apiClient, $"/albums/{albumId}/photos");
        }

        /// <summary>
        /// Load dictionary (key=albumId,value=photos).
        /// </summary>
        /// <param name="apiClient"></param>
        /// <param name="albums">Albums for which photos will be uploaded.</param>
        /// <returns>Loaded album photos.</returns>
        public static async Task<IDictionary<int, IEnumerable<Photo>>> GetPhotosForPreviewByAlmubsAsync(
            this ApiClientService apiClient,
            IEnumerable<Album> albums)
        {
            var result = new Dictionary<int, IEnumerable<Photo>>();

            var tasks = albums.Select(async album =>
            {
                var photos = await apiClient.GetPhotosByAlbumIdAsync(album.Id);

                if (photos is null)
                {
                    return;
                }

                result.Add(album.Id, photos.Take(6));
            });

            await Task.WhenAll(tasks);
            return result;
        }

        private static async Task<TResult?> GetAsync<TResult>(ApiClientService apiClient, string uri)
        {
            var response = await apiClient.GetAsync<TResult>(uri);

            if (!response.IsSuccess)
            {
                ApiResponseHelper.HandleNotSuccessApiResponse(response);
                return default;
            }

            return response.Data!;
        }
    }
}
