using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Project.Presentation.AuthClasses
{
    public class Auth : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.Get("Staff") == null)
                context.Result = new RedirectResult("/Staff/StaffLogin");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.Session.Get("Staff") == null)
                context.Result = new RedirectResult("/Staff/StaffLogin");
        }

    }
}
