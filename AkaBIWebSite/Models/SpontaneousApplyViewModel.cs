using System.Web;

namespace AkaBIWebSite.Models
{
    public class SpontaneousApplyViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string SelectedLocation { get; set; }
        public string DesiredPosition { get; set; }
        public string LinkedinProfile { get; set; }
        public HttpPostedFileBase Cv { get; set; }
        public HttpPostedFileBase CoverLetter { get; set; }
    }
}