// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/08
// ----------------------------------------------------------------------

using System.Collections.Generic;

namespace Anwalt.Web.Features.Home.Models
{
    public class HomeServiceModel
    {
        public string Headline { get; set; }

        public string Description { get; set; }

        public IEnumerable<HomeCardModel> Cards { get; set; }
    }
}