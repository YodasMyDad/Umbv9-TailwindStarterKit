using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umb9.Core.Shared.Controllers;
using Umb9.Core.Shared.Services;
using Umb9.Core.UmbracoModels;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace Umb9.Core.Home.Controllers
{
    /// <summary>
    /// Controller for the home document type
    /// </summary>
    public class HomeController : BaseRenderController
    {
        private readonly IPublishedContentQuery _publishedContentQuery;
        private readonly CacheService _cacheService;

        public HomeController(IPublishedContentQuery publishedContentQuery, CacheService cacheService, ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor)
            : base(cacheService, logger, compositeViewEngine, umbracoContextAccessor)
        {
            _publishedContentQuery = publishedContentQuery;
            _cacheService = cacheService;
        }

        /// <summary>
        /// The default home page template
        /// </summary>
        /// <param name="model">Provides access to the current content as the strongly typed model Home</param>
        /// <returns></returns>
        public IActionResult Home(UmbracoModels.Home model)
        {
            var name = Website.Name;

            //_publishedContentQuery.ContentAtRoot();

            return CurrentTemplate(model);
        }
    }
}