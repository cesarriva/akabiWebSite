using AkaBIWebSite.Contracts.Interfaces;
using AkaBIWebSite.Infrastructure;
using System;
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

        private MailMessage CreateEmailMessage(string from, string to, string subject, string body, bool isBodyHtml)
        {
            var message = new MailMessage(from, to, subject, body);
            message.IsBodyHtml = isBodyHtml;
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

                var messageToSend = CreateEmailMessage(hostUserName, to, subject, body, isBodyHtml);
                smtpClient.Send(messageToSend);
            }
        }

        #endregion
    }
}
