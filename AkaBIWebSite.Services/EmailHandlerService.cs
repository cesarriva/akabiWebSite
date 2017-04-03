using AkaBIWebSite.Contracts.Dtos;
using AkaBIWebSite.Contracts.Interfaces;
using AkaBIWebSite.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace AkaBIWebSite.Services
{
    public class EmailHandlerService : IEmailHandlerService
    {
        #region Private 

        private readonly string smtpHost;
        private readonly int smtpPort;
        private readonly string hostUserName;
        private readonly string hostPassword;

        private MailMessage CreateEmailMessage(string from, string to, string subject, string body, bool isBodyHtml, List<FileAttachmentDto> attachaments)
        {
            var message = new MailMessage(from, to, subject, body);
            message.IsBodyHtml = isBodyHtml;

            if (attachaments != null && attachaments.Any())
            {
                foreach (var attachment in attachaments)
                {
                    message.Attachments.Add(new Attachment(attachment.FileStream, attachment.FileName, attachment.FileType));
                }
            }
            


            return message;
        }

        #endregion

        #region Constructor

        public EmailHandlerService()
        {
            smtpHost = ConfigSettingsHandler.ReadSetting(Constants.SmtpHostKey);
            smtpPort = Convert.ToInt32(ConfigSettingsHandler.ReadSetting(Constants.SmtpPortKey));
            hostUserName = ConfigSettingsHandler.ReadSetting(Constants.SmtpUserNameKey);
            hostPassword = ConfigSettingsHandler.ReadSetting(Constants.SmtpUserPasswordKey);
        }

        #endregion

        #region Interface implementations

        public void SendEmail(string to, string subject, string body, bool isBodyHtml = false)
        {
            using (var smtpClient = new SmtpClient(smtpHost, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(hostUserName, hostPassword);
                smtpClient.EnableSsl = true;

                var messageToSend = CreateEmailMessage(hostUserName, to, subject, body, isBodyHtml, null);
                smtpClient.Send(messageToSend);
            }
        }

        public void SendEmail(string to, string subject, string body, List<FileAttachmentDto> attachaments, bool isBodyHtml = false)
        {
            using (var smtpClient = new SmtpClient(smtpHost, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(hostUserName, hostPassword);
                smtpClient.EnableSsl = true;

                var messageToSend = CreateEmailMessage(hostUserName, to, subject, body, isBodyHtml, attachaments);
                smtpClient.Send(messageToSend);
            }
        }
        
        #endregion
    }
}
