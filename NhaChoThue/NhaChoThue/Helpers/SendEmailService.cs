using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.IO;
using RazorEngine;
using System.Text;
using System.ComponentModel;

namespace NhaChoThue.Helpers
{
    public class SendEmailService
    {
        public  string GetEmailBody<T>(string templatePath, dynamic model)
        {
            var template = File.ReadAllText(templatePath);
            var body = Razor.Parse<T>(template, model);
            return body;
        }

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the message we sent
            MailMessage msg = (MailMessage)e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("Cancel");
            }
            if (e.Error != null)
            {
                Console.WriteLine("Error");
            }
            else
            {
                // prompt user with message sent!
                // as we have the message object we can also display who the message
                // was sent to etc 
                Console.WriteLine("Ok");
            }

            // finally dispose of the message
            if (msg != null)
                msg.Dispose();
        }

        public  void SendEmail(System.Net.Mail.MailMessage message)
        {
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient mailClient = new SmtpClient();
            mailClient.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            //var log = new SendEmailResult() { Message = message };
            try
            {
                mailClient.SendAsync(message, message);
            }
            catch (Exception ex)
            {
            }

            //return log;
        }

        private  MailMessage GetEmail<T>(string templatePath,string toAddress, string sub,dynamic model)
        {
            var body = GetEmailBody<T>(templatePath, model);

            return new MailMessage("sfmsserver@gmail.com", toAddress, sub, body);
        }

        public  void SendEmail<T>(string templateFile, string Todress, string sub, dynamic Monel)
        {
            var email = GetEmail<T>(templateFile, Todress, sub, Monel);
            SendEmail(email);
        }

    }
}