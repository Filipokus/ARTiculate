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
using ARTiculate.Mock;
using ARTiculate.Data;

namespace ARTiculate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ArtistContext _db;
        private IARTiculateRepository aRTiculateRepository;


        public HomeController(ILogger<HomeController> logger, ArtistContext db, IARTiculateRepository aRTiculateRepository)
        {
            _logger = logger;
            _db = db;
            this.aRTiculateRepository = aRTiculateRepository;
        }

        public IActionResult Index()
        {
            if (_db.Artists.Count() == 0)
            {
                aRTiculateRepository.GetMockData(_db);
            }

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
