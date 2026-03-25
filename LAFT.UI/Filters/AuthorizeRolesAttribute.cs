using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LAFT.UI.Filters
{
    /// <summary>
    /// Si el usuario ya está autenticado pero no cumple los roles, no redirige otra vez a Login
    /// (comportamiento por defecto de Authorize), lo que provoca un bucle con ReturnUrl.
    /// </summary>
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Controller.TempData["AuthMessage"] =
                    "Su cuenta no tiene permiso para acceder a esa sección. Asigne el rol Analista o Administrador al usuario en la base de datos (tablas ASP.NET Identity).";
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Home", action = "Index" }));
                return;
            }

            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}
