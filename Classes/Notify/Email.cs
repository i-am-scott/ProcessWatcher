using ProcessWatcher.Classes;
using System.Net.Mail;

namespace ProcessWatcher.Notify
{
    static class Email
    {
        public static async void SendAsync(string to, string subject, string body)
        {
            MailMessage mail = new MailMessage("processwatcher@noreply.com", to)
            {
                Subject = subject,
                Body = body
            };

            SmtpClient client = new SmtpClient()
            {
                Host = "smpt.googlemail.com",
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };

            client.SendCompleted += Client_SendCompleted;
            await client.SendMailAsync(mail);
        }

        private static void Client_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            util.Log($"Email sent to user.");
        }
    }
}