namespace ValidationSample.Extensions
{
    using System.Web.Mvc;
    using Newtonsoft.Json;

    public class ValidatorActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Continue normally if the model is valid.
            if (filterContext.Controller.ViewData.ModelState.IsValid) return;

            var serializationSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var serializedModelState = JsonConvert.SerializeObject(
              filterContext.Controller.ViewData.ModelState,
              serializationSettings);

            var result = new ContentResult
            {
                Content = serializedModelState,
                ContentType = "application/json"
            };

            filterContext.HttpContext.Response.StatusCode = 400;
            filterContext.Result = result;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }
    }
}