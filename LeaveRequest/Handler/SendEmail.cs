﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LeaveRequest.Handler
{
    public class SendEmail
    {
        public void Send(string email)
        {
            var time24 = DateTime.Now.ToString("HH:mm:ss");


            MailMessage mm = new MailMessage("1997HelloWorld1997@gmail.com", email)
            {
                Subject = "Email Confirmation - " + time24 + ",",
                Body = "Hi," + "</br> Your password Has Been Changed." + "</br> Please login with your new password.",

                IsBodyHtml = true
            };
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                EnableSsl = true
            };
            NetworkCredential NetworkCred = new NetworkCredential("1997HelloWorld1997@gmail.com", "wwwsawwwsdwwwszwwwsx");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
        }
    }
}
