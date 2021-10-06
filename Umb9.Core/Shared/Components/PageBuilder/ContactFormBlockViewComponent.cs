using Microsoft.AspNetCore.Mvc;
using Umb9.Core.Shared.Models;

namespace Umb9.Core.Shared.Components.PageBuilder
{
    /// <summary>
    /// Contact form block view component
    /// </summary>
    [ViewComponent(Name = "contactFormBlock")]
    public class ContactFormBlockViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(BlockListViewModel model)
        {
            return View(model);
        }
    }
}