using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Web.Extensions;
using Web.Models;
using Web.Services;

namespace Web.Pages
{
    public partial class AlbumPage
    {
        #region Injected
        
        [Inject]
        public ApiClientService ApiClient { get; set; }

        #endregion

        #region Parameters

        [Parameter]
        public int Id { get; set; }

        #endregion

        private bool _isReandered;
        private Album? _album;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public AlbumPage()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        { }

        protected override async Task OnInitializedAsync()
        {
            await LoadAlbumAsync();
            await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            _isReandered = true;
        }

        private async Task LoadAlbumAsync()
        {
            _album = await ApiClient.GetAlbumByIdAsync(Id);
        }
    }
}