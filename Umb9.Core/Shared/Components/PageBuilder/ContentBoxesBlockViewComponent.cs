using Microsoft.AspNetCore.Mvc;
using Umb9.Core.Shared.Models;

namespace Umb9.Core.Shared.Components.PageBuilder
{
    /// <summary>
    /// Content boxes view component
    /// </summary>
    [ViewComponent(Name = "contentBoxesBlock")]
    public class ContentBoxesBlockViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(BlockListViewModel model)
        {
            return View(model);
        }
    }
}