using System.IO;
using System.Web;

namespace AkaBIWebSite.Contracts.Dtos
{
    public class SpontaneousApplyDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CountryCode { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string SelectedLocation { get; set; }

        public string DesiredPosition { get; set; }

        public string LinkedinProfile { get; set; }

        public Stream CvStream { get; set; }

        public string CvMimeType { get; set; }

        public string CvFileName { get; set; }

        public Stream CoverLetterStream { get; set; }

        public string CoverLetterMimeType { get; set; }

        public string CoverLetterFileName { get; set; }
    }
}
