// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/11
// ----------------------------------------------------------------------

namespace Anwalt.Web.Features.About.Models
{
    public class AboutLinksResponseModel
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public int Position { get; set; }

        public string ViewName { get; set; }
    }
}