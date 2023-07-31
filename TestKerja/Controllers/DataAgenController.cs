using Microsoft.AspNetCore.Mvc;

namespace TestKerja.Controllers
{
    public class DataAgenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
