namespace netCore.Hangfire.Application.Services
{
    public class EmailSender : IEmailSender
    {
        public void SendEmail(string[] email, string subject, string message)
        {
            foreach (var item in email)
            {
                Console.WriteLine($"Email sent to {item} with subject {subject} and message {message}");
            }
        }
    }
}
