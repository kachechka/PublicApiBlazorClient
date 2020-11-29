using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Extensions;
using Web.Models;
using Web.Services;

namespace Web.Pages
{
    public partial class AlbumsPage
    {
        #region Injected

        [Inject]
        protected ApiClientService ApiClient { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        #endregion

        private IEnumerable<Album>? _albums;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public AlbumsPage()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        { }

        protected override async Task OnInitializedAsync()
        {
            await LoadAlbumsAsync();
            await base.OnInitializedAsync();
        }

        private void ClickByAlbum(Album album)
        {
            NavigationManager.NavigateTo($"/album/{album.Id}");
        }

        private async Task LoadAlbumsAsync()
        {
            _albums = await ApiClient.GetAlbumsAsync();
        }
    }
}