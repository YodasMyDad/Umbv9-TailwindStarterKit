using Microsoft.AspNetCore.Mvc;
using Umb9.Core.Shared.Models;

namespace Umb9.Core.Shared.Components.PageBuilder
{
    /// <summary>
    /// Feature box view component
    /// </summary>
    [ViewComponent(Name = "featureBox")]
    public class FeatureBoxViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(BlockListViewModel model)
        {
            return View(model);
        }
    }
}