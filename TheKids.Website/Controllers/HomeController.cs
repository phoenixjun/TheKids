using System.Linq;
using System.Web.Mvc;
using TheKids.Infrastructure.Storage.EF;

namespace TheKids.Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
             var context = new TheKidsDbContext();
            var addresses = context.Children.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}