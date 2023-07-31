using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TestKerja.data;
using TestKerja.Models;
using TestKerja.Models.ViewModel;

namespace TestKerja.Controllers
{
  
    public class AccountController : Controller

    {
        private readonly MySqlContext _mysqlContext;
        private readonly MySqlContext _context;
        private readonly IWebHostEnvironment _env;

        public AccountController(MySqlContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
         
            return View();

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] AccountForm data)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var accoun = new Account()
            {
                username = data.username,
                email = data.email,
                phone = data.phone,
                password = data.password,

            };

            _context.Accounts.Add(accoun);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> Index([FromForm] Login data)
        {
            var admin = _mysqlContext.Accounts.Where(x => x.username == data.Username && x.password == data.Password).FirstOrDefault();
            if (admin != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim("username",admin.username),
                    new Claim("role","admin")
                };

                var identity = new ClaimsIdentity(claims, "Cookie", "name", "role");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(principal);

                return Redirect("/Registrasi/index");
            }

            return View();
        }



    }

}
