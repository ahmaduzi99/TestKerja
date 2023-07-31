using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using TestKerja.data;
using TestKerja.Models;

namespace TestKerja.Controllers
{
    public class DataArrayController : Controller
    {
        private readonly MySqlContext _context;
        private readonly IWebHostEnvironment _env;
        private static List<DataArray> dataArray = new List<DataArray>();

        public DataArrayController(MySqlContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Hasil()
        {
            return View();

        }

        [HttpPost]
        public IActionResult AddData(int[] data, int value)
        {
            int cek = 0;
            DataArray dataArray = new DataArray();

            for (int a = 0; a < data.Length; a++)
           {
                for(int b = 0; b < data.Length; b++)
                {
                    if (data[a] + data[b] == value)
                    {
                        ViewData["Hasil"] = "True";
                        ViewData["Angka1"] = data[b];
                        ViewData["Angka2"] = data[a];
                        cek = 1;
                        break;

                    }
                }
           }

            if(cek != 1)
            {

                ViewData["HasilSalah"] = "False";
            }
            return View("Index");
        }

    }
}