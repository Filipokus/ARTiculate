using ARTiculate.Models;
using ARTiculateDataAccessLibrary.DataAccess;
using ARTiculateDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ArtistContext _db;


        public HomeController(ILogger<HomeController> logger, ArtistContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            //if (_db.Artists.Count() == 0)
            //{
            //    var file = System.IO.File.ReadAllText("ArtItemMock.json");
            //    var result = JsonConvert.DeserializeObject<IEnumerable<ArtItem>>(file);
            //}
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
    }
}
