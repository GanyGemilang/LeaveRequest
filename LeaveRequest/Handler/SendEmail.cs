 using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LeaveRequest.Handler
{
    public class SendEmail
    {
        public void SendForgotPassword(string resetCode, string email)
        {
            var time24 = DateTime.Now.ToString("HH:mm:ss");

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("1997HelloWorld1997@gmail.com", "wwwsawwwsdwwwszwwwsx");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            NetworkCredential nc = new NetworkCredential("1997HelloWorld1997@gmail.com", "wwwsawwwsdwwwszwwwsx");
            smtp.Credentials = nc;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("1997HelloWorld1997@gmail.com", "Leave Request Reset Password");
            mailMessage.To.Add(new MailAddress(email));
            mailMessage.Subject = "Reset Password " + time24;
            mailMessage.IsBodyHtml = false;
            mailMessage.Body = "Hi " + "\nThis is new password for your account. " + resetCode + "\nThank You";
            smtp.Send(mailMessage);
        }
        public void SendRegister(string email)
        {
            var time24 = DateTime.Now.ToString("HH:mm:ss");

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("1997HelloWorld1997@gmail.com", "wwwsawwwsdwwwszwwwsx");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            NetworkCredential nc = new NetworkCredential("1997HelloWorld1997@gmail.com", "wwwsawwwsdwwwszwwwsx");
            smtp.Credentials = nc;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("1997HelloWorld1997@gmail.com", "Register Leave Request");
            mailMessage.To.Add(new MailAddress(email));
            mailMessage.Subject = "Register Account " + time24;
            mailMessage.IsBodyHtml = false;
            mailMessage.Body = "Hi " + "\nyour account has been active. " + "\nThank You";
            smtp.Send(mailMessage);
        }
        public void SendRequest(string email)
        {
            var time24 = DateTime.Now.ToString("HH:mm:ss");

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("1997HelloWorld1997@gmail.com", "wwwsawwwsdwwwszwwwsx");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            NetworkCredential nc = new NetworkCredential("1997HelloWorld1997@gmail.com", "wwwsawwwsdwwwszwwwsx");
            smtp.Credentials = nc;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("1997HelloWorld1997@gmail.com", "Leave Request");
            mailMessage.To.Add(new MailAddress(email));
            mailMessage.Subject = "Leave Request " + time24;
            mailMessage.IsBodyHtml = false;
            mailMessage.Body = "Hi " + "\nThank You For You Request. Your Request Is Being Processed" + "\nThank You";
            smtp.Send(mailMessage);
        }
    }
}