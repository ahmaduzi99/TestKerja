using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TestKerja.data;
using TestKerja.Models;
using TestKerja.Models.ViewModel;

namespace TestKerja.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MySqlContext _context;
        private readonly IWebHostEnvironment _env;

        public HomeController(MySqlContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

      
        [HttpPost]
        public async Task<IActionResult> Index([FromForm] Login data)
        {
            var admin = _context.Accounts.Where(x => x.username == data.Username && x.password == data.Password).FirstOrDefault();
            if (admin != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim("username",admin.username),
                    new Claim("role","admin")
                };

                var identity = new ClaimsIdentity(claims, "Cookie", "name", "role");
                var principal = new ClaimsPrincipal(identity);

              //  await HttpContext.SignInAsync(principal);

                return Redirect("/Dashboard/index");
            }

            return View();
        }
    }

}
