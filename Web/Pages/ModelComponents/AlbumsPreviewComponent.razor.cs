using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Extensions;
using Web.Models;
using Web.Services;

namespace Web.Pages.ModelComponents
{
    public partial class AlbumsPreviewComponent
    {
        #region Injected

        [Inject]
        protected ApiClientService ApiClient { get; set; }

        #endregion

        #region Parameters

        [Parameter]
        public IEnumerable<Album>? Albums { get; set; }
        [Parameter]
        public EventCallback<Album> OnClickByAlbum { get; set; }

        #endregion

        private bool _isRendered;
        private IDictionary<int, IEnumerable<Photo>>? _albumPhotos;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public AlbumsPreviewComponent()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        { }

        protected override async Task OnInitializedAsync()
        {
            await LoadAlbumsPhotosAsync();

            await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            _isRendered = true;
        }

        private async Task ClickByAlbumHandler(Album album)
        {
            if (OnClickByAlbum.HasDelegate)
            {
                await OnClickByAlbum.InvokeAsync(album);
            }
        }

        private async Task LoadAlbumsPhotosAsync()
        {
            if (Albums is null)
            {
                Console.Error.WriteLine("Album is null");
                return;
            }

            _albumPhotos = await ApiClient.GetPhotosForPreviewByAlmubsAsync(Albums);
        }
    }
}