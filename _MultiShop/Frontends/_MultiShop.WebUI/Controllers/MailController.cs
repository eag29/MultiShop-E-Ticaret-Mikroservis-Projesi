using _MultiShop.WebUI.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace _MultiShop.WebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult SendMail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMail(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage(mailRequest);

            /* Mesajın Geliş Yeri */
            MailboxAddress mailboxAddressFrom = new MailboxAddress("MultiShop Katalog", "emirali19078@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            /* Mesajın Gidiş Yeri */
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            /* Mesajın Konusu */
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.MessageContent;
            mimeMessage.Subject = mailRequest.Subject;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("emirali19078@gmail.com", "gfat fdzn gmzn uqyl");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            return View();
        }
    }
}
