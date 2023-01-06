using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Mail;

namespace GameHouse.Models
{
    public class KontaktModel : PageModel
    {
        public string isSend { get; set; }
        public void OnGet()
        {
        }

        public void OnPostSubmit()
        {
            var email = Request.Form["email"];
            var subject = Request.Form["teema"];
            var message = Request.Form["message"];

            SendMail(email, subject, message);

            //try
            //{
            //    SendMail(email, subject, message);
            //    isSend = "send";
            //}
            //catch (Exception)
            //{
            //    isSend = "failed";
            //    throw;
            //}

        }

        public bool SendMail(string email, string subject, string message1)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            message.From = new MailAddress("meeli@planet.ee");
            message.To.Add("meeli@planet.ee");
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = "<p>E-post: " + email + "</p>" + "<p>Sisu: " + message1 + "</p>";

            smtpClient.Port = 465;
            smtpClient.Host = "smtp.zone.ee";
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("e-maili aadress", "parool");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Send(message);
            ServicePointManager.ServerCertificateValidationCallback =
    (sender, certificate, chain, sslPolicyErrors) => true;
            return true;

        }
    }
}
