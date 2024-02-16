using Microsoft.AspNetCore.Identity.UI.Services;

namespace CatchMore.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //TODO: Actually Implement Email Sender
            return Task.CompletedTask;
        }
    }
}
