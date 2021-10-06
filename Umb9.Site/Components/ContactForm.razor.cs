using Blazored.FluentValidation;
using Microsoft.AspNetCore.Components;
using System.Text;
using System.Threading.Tasks;
using Umb9.Core.Forms.Models;
using Umb9.Core.Shared.Services;
using Umb9.Core.UmbracoModels;
using Umbraco.Cms.Core;

namespace Umb9.Site.Components
{
    public partial class ContactForm : ComponentBase
    {
        [Inject] protected IPublishedContentQuery PublishedContentQuery { get; set; }

        [Inject] protected EmailService EmailService { get; set; }

        [Parameter] public int WebsiteId { get; set; }

        private ContactFormViewModel ContactFormModel { get; set; } = new ContactFormViewModel();

        private FluentValidationValidator fluentValidationValidator;

        private bool ShowSpinner { get; set; }

        private bool MessageSent { get; set; }

        private bool SendSuccessful { get; set; }

        private Website Website { get; set; }

        /// <summary>
        /// Submits the contact form
        /// </summary>
        /// <returns></returns>
        private async Task SubmitValidForm()
        {
            ShowSpinner = true;

            var sb = new StringBuilder();
            sb.Append("<p>Name: ").Append(ContactFormModel.Name).Append("</p>")
                .Append("<p>Company: ").Append(ContactFormModel.Company).Append("</p>")
                .Append("<p>Email: ").Append(ContactFormModel.Email).Append("</p>")
                .Append("<p>Phone: ").Append(ContactFormModel.PhoneNumber).Append("</p>")
                .Append("<p>").Append(ContactFormModel.Message).Append("</p>");

            SendSuccessful = await EmailService.SendEmail(Website.WebsiteEmail, Website.WebsiteEmail, $"Email From {Website.WebsiteName}", sb.ToString()).ConfigureAwait(false);

            MessageSent = true;

            //this.StateHasChanged();
        }

        /// <summary>
        /// Executes code when the component is initialised
        /// </summary>
        protected override void OnInitialized()
        {
            Website = PublishedContentQuery.Content(WebsiteId) as Website;
        }

        //void PartialValidate()
        //{
        //    Console.WriteLine($"Partial validation result : {fluentValidationValidator.Validate(options => options.IncludeRuleSets("Names"))}");
        //}
    }
}