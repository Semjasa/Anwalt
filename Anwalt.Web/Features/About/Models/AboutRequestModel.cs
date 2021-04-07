// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/11
// ----------------------------------------------------------------------

using System.Collections.Generic;
using Anwalt.Web.Data.Models;

namespace Anwalt.Web.Features.About.Models
{
    public class AboutRequestModel
    {
        public string Headline { get; set; }

        public string Description { get; set; }

        public IEnumerable<AboutLinksResponseModel> Links { get; set; }
    }
}