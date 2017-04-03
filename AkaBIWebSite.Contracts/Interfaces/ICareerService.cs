using AkaBIWebSite.Contracts.Dtos;

namespace AkaBIWebSite.Contracts.Interfaces
{
    public interface ICareerService
    {
        void SendJobApplication(SpontaneousApplyDto jobApplication);
    }
}
