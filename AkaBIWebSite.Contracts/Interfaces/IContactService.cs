using AkaBIWebSite.Contracts.Dtos;

namespace AkaBIWebSite.Contracts.Interfaces
{
    public interface IContactService
    {
        void SendContactMessage(ContactMessageDto contactData);
    }
}
