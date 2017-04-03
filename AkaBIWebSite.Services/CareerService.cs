using AkaBIWebSite.Contracts.Interfaces;
using System;
using AkaBIWebSite.Contracts.Dtos;
using AkaBIWebSite.Infrastructure;
using System.Text;
using System.Collections.Generic;

namespace AkaBIWebSite.Services
{
    public class CareerService : ICareerService
    {
        #region Private

        private readonly IEmailHandlerService _emailHandler;

        private string ConstructBodyMessage(SpontaneousApplyDto jobApplication)
        {
            var stbBody = new StringBuilder();
            stbBody.Append("<h4>A new spontaneous job application was sent from the AkaBI WebSite, please, see the application info bellow:</h4>");

            stbBody.Append("<p><b>CANDIDATE</b></p>");
            stbBody.AppendFormat("<p><b>Name:</b> {0} {1}</p>", jobApplication.LastName.ToUpper(), jobApplication.FirstName);
            stbBody.AppendFormat("<p><b>E-mail:<b/> {0}</p>", jobApplication.Email);
            stbBody.AppendFormat("<p><b>Phone Number:</b> +{0} {1}</p>", jobApplication.CountryCode, jobApplication.PhoneNumber);
            stbBody.AppendFormat("<p><b>LinkedIn Profile:</b> <a href=\"{0}\">{0}</a></p>", jobApplication.LinkedinProfile ?? "Not informed");

            if (!string.IsNullOrEmpty(jobApplication.SelectedLocation) || !string.IsNullOrEmpty(jobApplication.DesiredPosition))
            {
                stbBody.Append("<p>-----------------------------------------</p>");
                stbBody.Append("<p><b>JOB POSITION</b></p>");

                stbBody.AppendFormat("<p><b>Preferred Job Location:</b> {0}</p>", jobApplication.SelectedLocation ?? "Not informed");
                stbBody.AppendFormat("<p><b>Desired Position:</b> {0}</p>", jobApplication.DesiredPosition ?? "Not informed");
            }

            return stbBody.ToString();
        }

        private string ConstructEmailSubject(SpontaneousApplyDto jobApplication)
        {
            var subject = string.Format("Spontaneous application received: {0} {1}", jobApplication.LastName.ToUpper(), jobApplication.FirstName);
            return subject;
        }

        #endregion

        #region Constructor

        public CareerService(IEmailHandlerService emailHandler)
        {
            _emailHandler = emailHandler;
        }

        #endregion

        #region Interface Implementations

        public void SendJobApplication(SpontaneousApplyDto jobApplication)
        {
            var sendTo = ConfigSettingsHandler.ReadSetting(Constants.JobApplicationToKey);

            var listOfAttachments = new List<FileAttachmentDto>
            {
                new FileAttachmentDto { FileStream = jobApplication.CvStream, FileType = jobApplication.CvMimeType, FileName = jobApplication.CvFileName },
                new FileAttachmentDto { FileStream = jobApplication.CoverLetterStream, FileType = jobApplication.CoverLetterMimeType, FileName = jobApplication.CoverLetterFileName }
            };

            _emailHandler.SendEmail(sendTo, ConstructEmailSubject(jobApplication), ConstructBodyMessage(jobApplication), listOfAttachments, true);
        }

        #endregion
    }
}
