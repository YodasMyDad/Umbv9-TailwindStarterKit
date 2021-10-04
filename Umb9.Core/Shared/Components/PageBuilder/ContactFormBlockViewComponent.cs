using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.Blocks;

namespace Umb9.Core.Shared.Components.PageBuilder
{
    /// <summary>
    /// Contact form block view component
    /// </summary>
    [ViewComponent(Name = "contactFormBlock")]
    public class ContactFormBlockViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(BlockListItem model)
        {
            return View(model);
        }
    }
}
