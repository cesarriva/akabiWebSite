using AkaBIWebSite.Contracts.Dtos;
using AkaBIWebSite.Contracts.Interfaces;
using AkaBIWebSite.Models;
using System.Web.Mvc;

namespace AkaBIWebSite.Controllers
{
    public class CareersController : BaseController
    {
        private readonly ITaleevoApiHandlerService _taleevoService;
        private readonly ICareerService _careerService;

        public CareersController(ITaleevoApiHandlerService taleevoService, ICareerService careerService)
        {
            _taleevoService = taleevoService;
            _careerService = careerService;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "AkaBI | Careers";
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
        public ContentResult SubmitSpontaneouslyApplication(SpontaneousApplyViewModel jobApplication)
        {
            DoModelStateValidation();

            var dto = Mapper.Map<SpontaneousApplyDto>(jobApplication);
            _careerService.SendJobApplication(dto);

            return Json(new { success = true, message = "We received you application, we will contact you soon." });
        }

    }
}