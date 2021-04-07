// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/02
// ----------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Anwalt.Web.Infrastructure.Filters
{
    public class ModelOrNotFoundActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(!(context.Result is ObjectResult result)) return;

            var model = result.Value;

            if (model == null)
            {
                context.Result = new NotFoundResult();
            }
        }
    }
}