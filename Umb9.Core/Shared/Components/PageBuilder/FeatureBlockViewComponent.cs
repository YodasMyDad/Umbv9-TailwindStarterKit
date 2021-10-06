using Microsoft.AspNetCore.Mvc;
using Umb9.Core.Shared.Models;

namespace Umb9.Core.Shared.Components.PageBuilder
{
    /// <summary>
    /// Feature block view component
    /// </summary>
    [ViewComponent(Name = "featureBlock")]
    public class FeatureBlockViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(BlockListViewModel model)
        {
            return View(model);
        }
    }
}