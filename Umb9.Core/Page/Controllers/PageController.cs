using Microsoft.AspNetCore.Mvc;
using Umb9.Core.Shared.Controllers;
using Umb9.Core.Shared.Services;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;

namespace Umb9.Core.Page.Controllers
{
    /// <summary>
    /// Controller for the home document type
    /// </summary>
    public class PageController : BaseController
    {
        public PageController(
            CacheService cacheService,
            IUmbracoContextAccessor umbracoContextAccessor,
            IUmbracoDatabaseFactory databaseFactory,
            ServiceContext services,
            AppCaches appCaches,
            IProfilingLogger profilingLogger,
            IPublishedUrlProvider publishedUrlProvider) :
            base(cacheService, umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
        }

        /// <summary>
        /// The default page template
        /// </summary>
        /// <param name="model">Provides access to the current content as the strongly typed model Page</param>
        /// <returns></returns>
        public IActionResult Page(UmbracoModels.Page model)
        {
            model.RootNodeId = Website.Id;
            return CurrentTemplate(model);
        }
    }
}