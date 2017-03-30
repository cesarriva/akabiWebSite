using AkaBIWebSite.Contracts.Interfaces;

using AkaBIWebSite.Contracts.Dtos;
using System.Text;
using AkaBIWebSite.Infrastructure;
using System;

namespace AkaBIWebSite.Services
{
    public class ContactService : IContactService
    {
        #region Private 

        private readonly IEmailHandlerService _emailHandler;

        private string ConstructBodyMessage(ContactMessageDto contactData)
        {
            var stbBody = new StringBuilder();
            stbBody.Append("<h4>You have just received a new contact message from the AkaBI WebSite.</h4>");
            stbBody.Append("<p>Contact info:</p>");
            stbBody.AppendFormat("<p><b>Name:</b> {0}</p>", contactData.Name);
            stbBody.AppendFormat("<p><b>E-mail:<b/> {0}</p>", contactData.Email);
            stbBody.Append("<br/>-----------------Message----------------------<br/>");
            stbBody.AppendFormat("<p>{0}</p>", HtmlStringFormatUtils.ReplaceBreakLineByHtmlParagraph(contactData.Message));

            return stbBody.ToString();
        }

        #endregion

        #region Constructor

        public ContactService(IEmailHandlerService emailHandler)
        {
            _emailHandler = emailHandler;
        }

        #endregion

        #region Interface Implementations

        public void SendContactMessage(ContactMessageDto contactData)
        {
            var sendTo = ConfigSettingsHandler.ReadSetting(Constants.ContactToKey);
            _emailHandler.SendEmail(sendTo, contactData.Subject, ConstructBodyMessage(contactData), true);
        }

        #endregion
    }
}
