using Microsoft.AspNetCore.Mvc;
using Umb9.Core.Shared.Models;
using Umbraco.Cms.Core.Models.Blocks;

namespace Umb9.Core.Shared.Components.PageBuilder
{
    /// <summary>
    /// Call to action block view component
    /// </summary>
    [ViewComponent(Name = "callToActionBlock")]
    public class CallToActionBlockViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(BlockListViewModel model)
        {
            return View(model);
        }
    }
}