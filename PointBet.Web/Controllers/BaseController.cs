using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PointBet.Services.BaseServices;
using System.Linq;
using System.Security.Claims;

namespace PointBet.Web.Controllers
{
    public class BaseController : Controller
    {
        public static int _userId = 0;
        public static string _userRole = "";
        public IBaseFactory baseFactory;

        public BaseController(IBaseFactory baseFactory)
        {
            this.baseFactory = baseFactory;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ActionName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)filterContext.ActionDescriptor).ActionName;
            var ControllerName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)filterContext.ActionDescriptor).ControllerName;

            _userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);
            _userRole = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;

            string key = $"{ControllerName.ToLowerInvariant()}.{ActionName.ToLowerInvariant()}";

            filterContext.RouteData.Values["Controller"] = ControllerName;
            filterContext.RouteData.Values["Action"] = ActionName;

            base.OnActionExecuting(filterContext);

        }
    }
}
