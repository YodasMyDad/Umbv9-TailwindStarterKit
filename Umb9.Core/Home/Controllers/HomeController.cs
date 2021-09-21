using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umb9.Core.UmbracoModels;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace Umb9.Core.Home.Controllers
{
    public class HomeController : RenderController
    {
        public HomeController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor)
            : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
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

        /// <summary>
        /// This action is used when the template name matches the method name.
        /// </summary>
        /// <param name="model">Provides access to the current content as the strongly typed model Homepage</param>
        /// <returns></returns>
        public IActionResult Home(UmbracoModels.Home model) //credit to https://github.com/bakersbakebread for finding this one.
        {
            return CurrentTemplate(model);
        }
    }
}
