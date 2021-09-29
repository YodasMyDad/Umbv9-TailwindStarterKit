using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.Blocks;

namespace Umb9.Core.Shared.Components.PageBuilder
{
    /// <summary>
    /// Feature box view component
    /// </summary>
    [ViewComponent(Name = "questionAnswer")]
    public class QuestionAnswerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(BlockListItem model)
        {
            return View(model);
        }
    }
}