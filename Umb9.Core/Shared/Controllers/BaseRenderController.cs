using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umb9.Core.UmbracoModels;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace Umb9.Core.Shared.Controllers
{
    /// <summary>
    /// Base controller for all Umbraco page controllers
    /// </summary>
    public class BaseRenderController : RenderController
    {
        private readonly Services.CacheService _cacheService;

        public BaseRenderController(Services.CacheService cacheService, ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor)
            : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _cacheService = cacheService;
        }

        /// <summary>
        /// Gets the root Website which contains most of the site settings
        /// </summary>
        public Website Website
        {
            get
            {
                var rootSiteId = _cacheService.CachedRootContentId(CurrentPage);
                return UmbracoContext.Content.GetById(rootSiteId) as Website;
            }
        }
    }
}