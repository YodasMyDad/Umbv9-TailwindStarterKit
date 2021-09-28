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

///// <summary>
///// Overrides RenderControllers default action.
///// The Current content is accessible via CurrentPage as IPublishContent
///// </summary>
///// <returns></returns>
//public override IActionResult Index()
//{
//    return CurrentTemplate(CurrentPage);
//}

///// <summary>
///// This action is used when the template name matches the method name.
///// /// The Current content is accessible via CurrentPage as IPublishContent
///// </summary>
///// <returns></returns>
//public IActionResult HomePage2()
//{
//    return CurrentTemplate(CurrentPage);
//}

///// <summary>
///// This action is used when the template name matches the method name.
///// </summary>
///// <param name="model">Provides access to the current content using model.Content as IPublishContent</param>
///// <returns></returns>
//public IActionResult HomePage3(ContentModel model)
//{
//    return CurrentTemplate(model);
//}

///// <summary>
///// This action is used when the template name matches the method name.
///// </summary>
///// <param name="model">Provides access to the current content using model.Content as the strongly typed model Homepage</param>
///// <returns></returns>
//public IActionResult HomePage(ContentModel<UmbracoModels.Home> model)
//{
//    return CurrentTemplate(model);
//}