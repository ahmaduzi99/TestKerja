using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using TestKerja.data;
using TestKerja.Models;

namespace TestKerja.Controllers
{
    public class RegistrasiController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly MySqlContext _context;
        private readonly IWebHostEnvironment _env;

        public RegistrasiController(MySqlContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
			List<Registrasi> regis = _context.Regis.ToList();
			return View(regis);
		}

        public IActionResult Detail(int id)
        {
            var regis = _context.Regis.FirstOrDefault(x => x.Id == id);


            return View(regis);
        }

        public IActionResult Delete(int id)
        {
            var regis = _context.Regis.FirstOrDefault(x => x.Id == id);
            _context.Regis.Remove(regis);
            _context.SaveChanges();
            return RedirectToAction("Index", "Registrasi");
        }

		public IActionResult Edit(int id)
		{
			var regis = _context.Regis.FirstOrDefault(x => x.Id == id);
			return View(regis);

		}


		[HttpPost]
		public IActionResult Edit([FromForm] Registrasi data)
		{
			_context.Regis.Update(data);
			_context.SaveChanges();
			return RedirectToAction("index", "Registrasi");
		}

		public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] Registrasi data)
        {



            var regis = new Registrasi()
            {
                RegDate = data.RegDate,
                RegStatus = data.RegStatus,
                Name = data.Name,
                gender = data.gender,
                BirthPlace = data.BirthPlace,
                BrithDate = data.BrithDate,
                Adress = data.Adress,
                Email = data.Email,
                Phone = data.Phone,
                IdCard = data.IdCard,
                CreateDate = data.CreateDate,
                CreateBy = data.CreateBy,

            };

            _context.Regis.Add(regis);
            _context.SaveChanges();
            return RedirectToAction("Index", "Registrasi");
        }
    }
}
