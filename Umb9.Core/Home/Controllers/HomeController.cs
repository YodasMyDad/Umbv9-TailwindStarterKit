using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text;
using System.Threading.Tasks;
using Umb9.Core.Forms.Models;
using Umb9.Core.Shared.Controllers;
using Umb9.Core.Shared.Services;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Configuration.Models;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Mail;
using Umbraco.Cms.Core.Models.Email;
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
        private readonly IEmailSender _emailSender;
        private readonly ILogger<HomeController> _logger;
        private readonly GlobalSettings _globalSettings;
        private readonly IPublishedContentQuery _publishedContentQuery;
        private readonly CacheService _cacheService;

        public HomeController(
            IOptions<GlobalSettings> globalSettings,
            IPublishedContentQuery publishedContentQuery,
            IEmailSender emailSender,
            ILogger<HomeController> logger,
            CacheService cacheService,
            IUmbracoContextAccessor umbracoContextAccessor,
            IUmbracoDatabaseFactory databaseFactory,
            ServiceContext services,
            AppCaches appCaches,
            IProfilingLogger profilingLogger,
            IPublishedUrlProvider publishedUrlProvider) :
            base(cacheService, umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _cacheService = cacheService;
            _publishedContentQuery = publishedContentQuery;
            _emailSender = emailSender;
            _logger = logger;
            _globalSettings = globalSettings.Value;
        }

        /// <summary>
        /// The default home page template
        /// </summary>
        /// <param name="model">Provides access to the current content as the strongly typed model Home</param>
        public IActionResult Home(UmbracoModels.Home model)
        {
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
            var successfullySent = false;

            try
            {
                var fromAddress = _globalSettings.Smtp.From;

                var sb = new StringBuilder();
                sb.Append("<p>Name: ").Append(model.Name).Append("</p>")
                    .Append("<p>Company: ").Append(model.Company).Append("</p>")
                    .Append("<p>Email: ").Append(model.Email).Append("</p>")
                    .Append("<p>Phone: ").Append(model.PhoneNumber).Append("</p>")
                    .Append("<p>").Append(model.Message).Append("</p>");

                var message = new EmailMessage(fromAddress, fromAddress, "Contact Form Message", sb.ToString(), true);
                await _emailSender.SendAsync(message, emailType: "Contact").ConfigureAwait(false);
                successfullySent = true;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error When Submitting Contact Form");
            }

            TempData[Shared.Constants.TempDataKeys.ContactFormSent] = successfullySent;
            return RedirectToCurrentUmbracoPage();
        }
    }
}