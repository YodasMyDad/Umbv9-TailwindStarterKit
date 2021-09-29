using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.Blocks;

namespace Umb9.Core.Shared.Components.PageBuilder
{
    /// <summary>
    /// question and answer block view component
    /// </summary>
    [ViewComponent(Name = "questionAnswerBlock")]
    public class QuestionAnswerBlockViewComponents : ViewComponent
    {
        public IViewComponentResult Invoke(BlockListItem model)
        {
            return View(model);
        }
    }
}