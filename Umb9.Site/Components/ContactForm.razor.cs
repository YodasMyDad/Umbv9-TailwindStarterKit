using Blazored.FluentValidation;
using Microsoft.AspNetCore.Components;
using Umb9.Core.Forms.Models;
using Umb9.Core.UmbracoModels;
using Umbraco.Cms.Core;

namespace Umb9.Site.Components
{
    public partial class ContactForm : ComponentBase
    {
        [Inject] protected IPublishedContentQuery PublishedContentQuery { get; set; }

        [Parameter] public int WebsiteId { get; set; }

        private ContactFormViewModel ContactFormModel { get; set; } = new ContactFormViewModel();

        private FluentValidationValidator fluentValidationValidator;

        private bool ShowSpinner { get; set; }

        private bool MessageSent { get; set; }

        private Website Website { get; set; }

        private void SubmitValidForm()
        {
            ShowSpinner = true;
        }

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