// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/02
// ----------------------------------------------------------------------

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Anwalt.Web.Features.Abstractions
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiBaseController : ControllerBase { }
}