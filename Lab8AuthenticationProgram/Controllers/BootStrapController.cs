using System.Web.Mvc;

namespace Lab8AuthenticationProgram.Controllers
{
    [Authorize]
    public class BootStrapController : Controller
    {
        // GET: BootStrap
        public ActionResult Index()
        {
            return View();
        }
    }
}