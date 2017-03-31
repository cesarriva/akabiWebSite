using AkaBIWebSite.Contracts.Dtos;

namespace AkaBIWebSite.Contracts.Interfaces
{
    public interface ITaleevoApiHandlerService
    {
        CareerPositionsDto GetJobPositions();
    }
}
