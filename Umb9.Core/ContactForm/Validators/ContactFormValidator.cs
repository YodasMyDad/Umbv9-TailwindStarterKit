using FluentValidation;
using Umb9.Core.Forms.Models;

namespace Umb9.Core.ContactForm.Validators
{
    /// <summary>
    /// Contact form validator
    /// </summary>
    public class ContactFormValidator : AbstractValidator<ContactFormViewModel>
    {
        public ContactFormValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("You must enter your Name");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("You must enter a Email address")
                .EmailAddress().WithMessage("You must provide a valid Email address");

            RuleFor(p => p.Message)
                .NotEmpty().WithMessage("You must enter a message");
        }
    }
}