using System.IO;
using System.Net.Mime;

namespace AkaBIWebSite.Contracts.Dtos
{
    public class FileAttachmentDto
    {
        public string FileType { get; set; }
        public Stream FileStream { get; set; }
        public string FileName { get; set; }
    }
}
