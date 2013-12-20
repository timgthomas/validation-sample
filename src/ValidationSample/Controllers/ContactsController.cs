namespace ValidationSample.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using Models;

    public class ContactsController : Controller
    {
        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public HttpStatusCodeResult Add(ContactModel model)
        {
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}