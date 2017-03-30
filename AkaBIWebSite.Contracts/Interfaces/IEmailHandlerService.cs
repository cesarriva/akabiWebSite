namespace AkaBIWebSite.Contracts.Interfaces
{
    public interface IEmailHandlerService
    {
        void SendEmail(string to, string subject, string body, bool isBodyHtml = false);
    }
}
