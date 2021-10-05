using Microsoft.AspNetCore.Mvc;
using Umb9.Core.UmbracoModels;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Website.Controllers;

namespace Umb9.Core.Shared.Controllers
{
    /// <summary>
    /// Base controller for all Umbraco page controllers
    /// </summary>
    public class BaseController : SurfaceController, IRenderController
    {
        private readonly Services.CacheService _cacheService;

        public BaseController(Services.CacheService cacheService,
            IUmbracoContextAccessor umbracoContextAccessor,
            IUmbracoDatabaseFactory databaseFactory,
            ServiceContext services,
            AppCaches appCaches,
            IProfilingLogger profilingLogger,
            IPublishedUrlProvider publishedUrlProvider) :
            base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _cacheService = cacheService;
        }

        /// <summary>
        ///     Locates the template for the given route
        /// </summary>
        /// <typeparam name="T">Model type</typeparam>
        /// <param name="model">Instance of model</param>
        /// <param name="viewName">View name</param>
        /// <returns>Template for given route</returns>
        protected ActionResult CurrentTemplate<T>(T model, string viewName = "")
        {
            if (string.IsNullOrEmpty(viewName))
            {
                viewName = ControllerContext.RouteData.Values["action"].ToString();
            }

            return View(viewName, model);
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