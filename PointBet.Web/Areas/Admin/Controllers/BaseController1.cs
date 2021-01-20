using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PointBet.Services.BaseServices;
using System.Security.Claims;

namespace PointBet.Web.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public IBaseFactory baseFactory;

        public BaseController(IBaseFactory baseFactory)
        {
            this.baseFactory = baseFactory;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ActionName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)filterContext.ActionDescriptor).ActionName;
            var ControllerName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)filterContext.ActionDescriptor).ControllerName;
            string key = $"{ControllerName.ToLowerInvariant()}.{ActionName.ToLowerInvariant()}";

            filterContext.RouteData.Values["Controller"] = ControllerName;
            filterContext.RouteData.Values["Action"] = ActionName;

            base.OnActionExecuting(filterContext);

        }
    }
}