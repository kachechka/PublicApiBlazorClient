using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models;
using Web.Services;
using Web.Extensions;

namespace Web.Pages
{
    public partial class UsersPage
    {
        #region Injected

        [Inject]
        public ApiClientService ApiClient { get; set; }

        #endregion

        private IEnumerable<User>? _users;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public UsersPage()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        { }

        protected override async Task OnInitializedAsync()
        {
            await LoadUsersAsync();
            await base.OnInitializedAsync();
        }

        private async Task LoadUsersAsync()
        {
            _users = await ApiClient.GetUsersAsync();
        }
    }
}