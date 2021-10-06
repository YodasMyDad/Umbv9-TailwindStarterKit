using Microsoft.AspNetCore.Mvc;
using Umb9.Core.Shared.Models;

namespace Umb9.Core.Shared.Components.PageBuilder
{
    /// <summary>
    /// Article block view component
    /// </summary>
    [ViewComponent(Name = "articleBlock")]
    public class ArticleBlockViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(BlockListViewModel model)
        {
            return View(model);
        }
    }
}