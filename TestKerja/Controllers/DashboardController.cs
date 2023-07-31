using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TestKerja.data;
using TestKerja.Models;

namespace TestKerja.Controllers
{
    public class DashboardController : Controller
	{

		private readonly MySqlContext _context;
		private readonly IWebHostEnvironment _env;

		public DashboardController(MySqlContext context, IWebHostEnvironment env)
		{
			_context = context;
			_env = env;
		}
		public IActionResult Index()
        {
			List<Registrasi> regis = _context.Regis.ToList();
			return View(regis);
        }
    }
}
