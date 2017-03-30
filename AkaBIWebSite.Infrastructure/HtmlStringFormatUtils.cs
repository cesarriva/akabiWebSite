using System;
using System.Text;

namespace AkaBIWebSite.Infrastructure
{
    public static class HtmlStringFormatUtils
    {
        public static string ReplaceBreakLineByHtmlParagraph(string text)
        {
            var separator = new string[] { "\n" };
            string[] paragraphs = text.Split(separator, StringSplitOptions.None);

            var stb = new StringBuilder();

            foreach (var paragraph in paragraphs)
            {
                stb.AppendFormat("<p>{0}</p>", paragraph);
            }

            return stb.ToString();
        }
    }
}
