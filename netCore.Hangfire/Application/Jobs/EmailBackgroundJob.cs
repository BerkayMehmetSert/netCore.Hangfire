using netCore.Hangfire.Application.Services;
using static netCore.Hangfire.Application.Constants.BackgroundJobMessage;
namespace netCore.Hangfire.Application.Jobs
{
    public class EmailBackgroundJob
    {
        private readonly IEmailSender _emailSender;

        public EmailBackgroundJob(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void SendEmailWithProduct(string name, double price)
        {
            var productMessage = string.Format(EmailProductMessage, name, price);
            var emailList = new string[] { EmailAddress };

            _emailSender.SendEmail(emailList, EmailSubject, productMessage);
        }

    }
}
