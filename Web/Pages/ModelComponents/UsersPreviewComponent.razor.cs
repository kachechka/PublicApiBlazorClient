using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using Web.Models;

namespace Web.Pages.ModelComponents
{
    public partial class UsersPreviewComponent
    {
        #region Parameters

        /// <summary>
        /// Gets or sets users for render.
        /// </summary>
        /// <value>Users for render.</value>
        [Parameter]
        public IEnumerable<User>? Users { get; set; }

        #endregion

        public UsersPreviewComponent()
        { }
    }
}