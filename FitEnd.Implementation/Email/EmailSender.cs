using FitEnd.Application.Dto;
using FitEnd.Application.Email;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace FitEnd.Implementation.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly string EmailSalje;
        private readonly string SifraEmaila;

        public EmailSender(string EmailSalje, string SifraEmaila)
        {
            this.EmailSalje = EmailSalje;
            this.SifraEmaila = SifraEmaila;
        }
        public void sendEmail(SendEmailDto dto)
        {

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(EmailSalje, SifraEmaila)
            };

            var message = new MailMessage(EmailSalje, dto.komeSeSalje);
            message.Subject = dto.Subject;
            message.Body = dto.Content;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
    }
}
