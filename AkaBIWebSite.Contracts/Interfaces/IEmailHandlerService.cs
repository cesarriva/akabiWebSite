using AkaBIWebSite.Contracts.Dtos;
using System.Collections.Generic;

namespace AkaBIWebSite.Contracts.Interfaces
{
    public interface IEmailHandlerService
    {
        void SendEmail(string to, string subject, string body, bool isBodyHtml = false);
        void SendEmail(string to, string subject, string body, List<FileAttachmentDto> listOfAttachments, bool isBodyHtml = false);
    }
}
