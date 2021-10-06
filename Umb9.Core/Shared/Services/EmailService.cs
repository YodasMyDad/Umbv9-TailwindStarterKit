using Ganss.XSS;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Mail;
using Umbraco.Cms.Core.Models.Email;

namespace Umb9.Core.Shared.Services
{
    /// <summary>
    /// Service that deals with sending and receiving email
    /// </summary>
    public class EmailService
    {
        private readonly IEmailSender _emailSender;
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger, IEmailSender emailSender)
        {
            _logger = logger;
            _emailSender = emailSender;
        }

        /// <summary>
        /// Sends and email using the default settings, set in the appsettings.json file
        /// </summary>
        /// <param name="from">from Email address</param>
        /// <param name="to">to email address</param>
        /// <param name="subject">Subject for the email</param>
        /// <param name="message">The main email message, can hbe HTML</param>
        /// <returns></returns>
        public async Task<bool> SendEmail(string from, string to, string subject, string message, string emailType = "default")
        {
            try
            {
                var sanitizer = new HtmlSanitizer();
                var email = new EmailMessage(from, to, sanitizer.Sanitize(subject), sanitizer.Sanitize(message), true);
                await _emailSender.SendAsync(email, emailType).ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when sending email");
                return false;
            }
        }
    }
}