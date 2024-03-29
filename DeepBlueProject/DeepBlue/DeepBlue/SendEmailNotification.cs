using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

namespace DeepBlue
{
    public static class SendEmailNotification
    {
        public static bool SendNotification(string msg,string SenderEmail,string SendName)
        {
            try
            {

                var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();


                string host = configuration["EmailSender:SmtpHost"].ToString();
                int port = int.Parse(configuration["EmailSender:SmtpPort"].ToString());

                string sender = configuration["EmailSender:SmtpCredential:UserName"].ToString();
                string password = configuration["EmailSender:SmtpCredential:Password"].ToString();

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("", SenderEmail));
                message.To.Add(new MailboxAddress("", sender));

                var bodyBuilder = new BodyBuilder();

                bodyBuilder.HtmlBody = $"{msg}";

                // bodyBuilder.TextBody = "This is some plain text";

                message.Body = bodyBuilder.ToMessageBody();
               // message.Body = new TextPart("plain") { Text = msg };


                using (var client = new SmtpClient())
                {
                    client.Connect(host, port, SecureSocketOptions.StartTls);
                    client.Authenticate(sender, password);
                    client.Send(message);
                    client.Disconnect(true);
                }

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
