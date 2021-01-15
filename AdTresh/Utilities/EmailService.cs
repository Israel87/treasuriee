using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace AdTresh.Utilities
{
    public class EmailService
    {

        private static readonly string Sender = ConfigurationManager.AppSettings["Sender"];
        private static readonly string Password = ConfigurationManager.AppSettings["Password"];
        private static readonly int Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
        private static readonly bool EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
        private static readonly string SmtpServer = ConfigurationManager.AppSettings["SmtpServer"];

        public static bool SendCounterPartyEmail(string ToEmail, string Subject, string Message)
        {

            var sendMailCheck = false;

            try
            {

                // initialize the smtp class.
                var client = new SmtpClient();
                client.EnableSsl = true;
                client.Port = Port;
                client.Host = SmtpServer;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                NetworkCredential networkCredentials = new NetworkCredential();
                networkCredentials.UserName = Sender;
                networkCredentials.Password = Password;
                client.Credentials = networkCredentials;

                // initialize the MailMessage class.

                var mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(Sender, "SDA Church Festac Treasury");
                mailMessage.Subject = Subject;
                mailMessage.Body = Message;

                string[] Multi = ToEmail.Split(';');
                foreach (string Multiemail in Multi)
                {
                    mailMessage.To.Add(new MailAddress(Multiemail));
                };
                mailMessage.IsBodyHtml = true;
                mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                //sendMailCheck =  
                client.Send(mailMessage);
                sendMailCheck = true;


            }
            catch (Exception ex)
            {

            }
            return sendMailCheck;

        }

        // send mail to single email 
        public static bool SendSingleEmail(string ToEmail, string Subject, string Message)
        {
            var sendMailCheck = false;

            try
            {
                // initialize the smtp class.
                var client = new SmtpClient();
                client.EnableSsl = true;
                client.Port = Port;
                client.Host = SmtpServer;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                NetworkCredential networkCredentials = new NetworkCredential();
                networkCredentials.UserName = Sender;
                networkCredentials.Password = Password;
                client.Credentials = networkCredentials;

                // initialize the MailMessage class.
                var mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(Sender, "Parthian Partners Limited");
                mailMessage.Subject = Subject;
                mailMessage.Body = Message;

                mailMessage.To.Add(new MailAddress(ToEmail));
                mailMessage.IsBodyHtml = true;
                mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;


                client.Send(mailMessage);
                sendMailCheck = true;
            }
            catch (Exception ex)
            {

            }

            return sendMailCheck;
        }
    }
}