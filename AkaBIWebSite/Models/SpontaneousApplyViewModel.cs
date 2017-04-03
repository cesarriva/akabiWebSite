using System.ComponentModel.DataAnnotations;
using System.Web;

namespace AkaBIWebSite.Models
{
    public class SpontaneousApplyViewModel
    {
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Country Code is required.")]
        public string CountryCode { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Type a valid Email.")]
        public string Email { get; set; }

        public string SelectedLocation { get; set; }

        public string DesiredPosition { get; set; }

        public string LinkedinProfile { get; set; }

        [Required(ErrorMessage = "A CV is required.")]
        public HttpPostedFileBase Cv { get; set; }

        [Required(ErrorMessage = "A Cover Letter is required.")]
        public HttpPostedFileBase CoverLetter { get; set; }
    }
}