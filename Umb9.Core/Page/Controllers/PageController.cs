using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umb9.Core.Shared.Controllers;
using Umb9.Core.Shared.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace Umb9.Core.Page.Controllers
{
    /// <summary>
    /// Controller for the home document type
    /// </summary>
    public class PageController : BaseRenderController
    {
        public PageController(CacheService cacheService, ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor)
            : base(cacheService, logger, compositeViewEngine, umbracoContextAccessor)
        {
        }

        /// <summary>
        /// The default page template
        /// </summary>
        /// <param name="model">Provides access to the current content as the strongly typed model Page</param>
        /// <returns></returns>
        public IActionResult Page(UmbracoModels.Page model)
        {
            return CurrentTemplate(model);
        }
    }
}