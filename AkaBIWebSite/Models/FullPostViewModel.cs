using AkaBIWebSite.Utils;
using System;

namespace AkaBIWebSite.Models
{
    public class FullPostViewModel
    {
        public string Id { get; set; }

        public Uri FullPictureUrl { get; set; }

        public DateTime CreationDate { get; set; }

        public string CreationDateFormatted
        {
            get { return CreationDate.ToString("MMMM dd, yyyy - HH:mm").FirstLetterToUpper(); }
        }

        public string PostMessage { get; set; }

        public string PostMessageTruncated
        {
            get
            {
                if (string.IsNullOrEmpty(PostMessage))
                    return null;

                return PostMessage.TruncateString(370);
            }
        }
        
        public Uri FacebookPostLink { get; set; }
        
        public Uri FacebookFeedPostLink { get; set; }
    }
}