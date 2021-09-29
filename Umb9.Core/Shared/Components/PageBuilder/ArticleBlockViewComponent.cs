using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.Blocks;

namespace Umb9.Core.Shared.Components.PageBuilder
{
    /// <summary>
    /// Article block view component
    /// </summary>
    [ViewComponent(Name = "articleBlock")]
    public class ArticleBlockViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(BlockListItem model)
        {
            return View(model);
        }
    }
}