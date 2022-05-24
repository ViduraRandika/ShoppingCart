using System;
using System.Net;
using System.Net.Mail;

namespace LogicLayer.GenaralLogics
{
    public class SendEmailLogic
    {
        public bool sendEmail(string recipient, string subject, string body, string name)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("kahawalapiyasiri@gmail.com", "usaballa"),
                EnableSsl = true
            };

            try
            {
                smtpClient.Send("kahawalapiyasiri@gmail.com", recipient, subject, body);
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}