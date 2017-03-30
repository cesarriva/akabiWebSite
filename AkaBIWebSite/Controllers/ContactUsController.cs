using AkaBIWebSite.Contracts.Dtos;
using AkaBIWebSite.Contracts.Interfaces;
using AkaBIWebSite.Models;
using System.Web.Mvc;

namespace AkaBIWebSite.Controllers
{
    public class ContactUsController : BaseController
    {
        private readonly IContactService _contactService;

        public ContactUsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ContentResult SendContactMessage(ContactFormViewModel contactData)
        {
            DoModelStateValidation();

            var dto = Mapper.Map<ContactMessageDto>(contactData);
            _contactService.SendContactMessage(dto);

            return Json(new { success = true, message = "E-mail sent with success, we will contact you soon." });
        }
    }
}