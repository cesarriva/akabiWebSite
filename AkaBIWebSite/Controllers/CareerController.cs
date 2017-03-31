using AkaBIWebSite.Contracts.Interfaces;
using AkaBIWebSite.Models;
using System.Web.Mvc;

namespace AkaBIWebSite.Controllers
{
    public class CareerController : BaseController
    {
        private readonly ITaleevoApiHandlerService _taleevoService;

        public CareerController(ITaleevoApiHandlerService taleevoService)
        {
            _taleevoService = taleevoService;
        }

        public ActionResult Index()
        {
            var positionsDto = _taleevoService.GetJobPositions();

            var viewModel = Mapper.Map<CareerPositionsViewModel>(positionsDto);
            
            return View(viewModel);
        }
        
    }
}