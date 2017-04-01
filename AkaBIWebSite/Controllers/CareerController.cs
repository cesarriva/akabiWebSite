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
            return View();
        }

        public PartialViewResult JobOffersSection()
        {
            var positionsDto = _taleevoService.GetJobPositions();

            var viewModel = Mapper.Map<CareerPositionsViewModel>(positionsDto);

            return PartialView("_JobOffers", viewModel);
        }
        
        [HttpGet]
        public ActionResult ApplySpontaneously()
        {
            return View();
        }

        [HttpPost]
        public ContentResult SubmitSpontaneouslyApplication()
        {
            return Json(new { success = true, message = "We received you application, we will contact you soon." });
        }

    }
}