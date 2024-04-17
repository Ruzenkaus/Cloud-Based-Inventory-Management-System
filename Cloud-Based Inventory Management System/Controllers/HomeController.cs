using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cloud_Based_Inventory_Management_System.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
