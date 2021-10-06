using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;
using Umb9.Core.Forms.Models;
using Umb9.Core.Shared.Controllers;
using Umb9.Core.Shared.Services;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;

namespace Umb9.Core.Home.Controllers
{
    /// <summary>
    /// Controller for the home document type
    /// </summary>
    public class HomeController : BaseController
    {
        private readonly EmailService _emailService;

        public HomeController(
            CacheService cacheService,
            IUmbracoContextAccessor umbracoContextAccessor,
            IUmbracoDatabaseFactory databaseFactory,
            ServiceContext services,
            AppCaches appCaches,
            IProfilingLogger profilingLogger,
            IPublishedUrlProvider publishedUrlProvider,
            EmailService emailService) :
            base(cacheService, umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _emailService = emailService;
        }

        /// <summary>
        /// The default home page template
        /// </summary>
        /// <param name="model">Provides access to the current content as the strongly typed model Home</param>
        public IActionResult Home(UmbracoModels.Home model)
        {
            model.RootNodeId = Website.Id;
            return CurrentTemplate(model);
        }

        /// <summary>
        /// Sends the contact form from the contact block
        /// </summary>
        /// <param name="model"></param>
        /// <remarks>
        /// This is only here to prove you can have a render controller and a surface controller in one
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> SendContactForm(ContactFormViewModel model)
        {
            if (!ModelState.IsValid) return CurrentUmbracoPage();

            var sb = new StringBuilder();

            sb.Append("<p>Name: ").Append(model.Name).Append("</p>")
                .Append("<p>Company: ").Append(model.Company).Append("</p>")
                .Append("<p>Email: ").Append(model.Email).Append("</p>")
                .Append("<p>Phone: ").Append(model.PhoneNumber).Append("</p>")
                .Append("<p>").Append(model.Message).Append("</p>");

            TempData[Shared.Constants.TempDataKeys.ContactFormSent] = await _emailService.SendEmail(Website.WebsiteEmail, Website.WebsiteEmail, $"Email From {Website.WebsiteName}", sb.ToString()).ConfigureAwait(false);

            return RedirectToCurrentUmbracoPage();
        }
    }
}