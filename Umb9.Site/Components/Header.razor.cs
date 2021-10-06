using Microsoft.AspNetCore.Components;
using Umb9.Core.UmbracoModels;
using Umbraco.Cms.Core;

namespace Umb9.Site.Components
{
    public partial class Header : ComponentBase
    {
        [Inject] protected IPublishedContentQuery PublishedContentQuery { get; set; }

        [Parameter] public int RootId { get; set; }

        public Website Website { get; set; }

        public bool NavIsOpen { get; set; } = false;

        protected override void OnInitialized()
        {
            Website = PublishedContentQuery.Content(RootId) as Website;
        }

        private void OpenCloseNav()
        {
            if (NavIsOpen)
            {
                NavIsOpen = false;
            }
            else
            {
                NavIsOpen = true;
            }
        }
    }
}