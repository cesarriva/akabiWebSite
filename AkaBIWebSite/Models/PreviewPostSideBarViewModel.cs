using AkaBIWebSite.Utils;
using System;

namespace AkaBIWebSite.Models
{
    public class PreviewPostSideBarViewModel
    {
        public string Id { get; set; }

        public DateTime CreationDate { get; set; }

        public string CreationDateFormatted
        {
            get { return CreationDate.ToString("MMM dd yyyy").FirstLetterToUpper(); }
        }

        public Uri SmallPictureUrl { get; set; }

        public string PostMessage { get; set; }

        public string PostMessageTruncated
        {
            get
            {
                if (string.IsNullOrEmpty(PostMessage))
                    return null;

                return PostMessage.TruncateString(40);
            }
        }
    }
}