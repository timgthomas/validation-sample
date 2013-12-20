using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ValidationSample
{
    using Extensions;
    using FluentValidation.Mvc;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalFilters.Filters.Add(new ValidatorActionFilter());

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            FluentValidationModelValidatorProvider.Configure();
        }
    }
}
