using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Extensions;
using Web.Models;
using Web.Services;

namespace Web.Pages.ModelComponents
{
    public partial class AlbumPhotosComponent
    {
        #region Injected

        [Inject]
        protected ApiClientService ApiClient { get; set; }

        #endregion

        #region Parameters

        /// <summary>
        /// Gets or sets album for render.
        /// </summary>
        /// <value>Album for render.</value>
        [Parameter]
        public Album? Album { get; set; }

        #endregion

        private IEnumerable<Photo>? _photos;
        private bool _isRendered;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public AlbumPhotosComponent()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        { }

        protected override async Task OnInitializedAsync()
        {
            if (Album is null)
            {
                return;
            }

            _photos = await ApiClient.GetPhotosByAlbumIdAsync(Album.Id);
            _isRendered = true;

            await base.OnInitializedAsync();
        }
    }
}