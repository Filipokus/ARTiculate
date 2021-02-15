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
using ARTiculate.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using ARTiculate.Areas.Identity.Data;

namespace ARTiculate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ArtistContext _db;
        private IARTiculateRepository aRTiculateRepository;
        private readonly SignInManager<ARTiculateUser> _signInManager;
        

        public HomeController(ILogger<HomeController> logger, 
            ArtistContext db, 
            IARTiculateRepository aRTiculateRepository, 
            SignInManager<ARTiculateUser> signInManager
           )
        {
            _logger = logger;
            _db = db;
            this.aRTiculateRepository = aRTiculateRepository;
            _signInManager = signInManager;
            
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                List<Vernisage> futureVernisages = await aRTiculateRepository.GetAllVernisagesToCome();
                List<Vernisage> liveVernisages = await aRTiculateRepository.GetLiveVernisages();
                List<Exhibition> exhibitions = await aRTiculateRepository.GetAllExhibitionsOrderedByDate();
                List<Artist> artists = await aRTiculateRepository.GetAllArtists();

                HomeViewModel HomeViewModel = new HomeViewModel(futureVernisages, liveVernisages, exhibitions, artists);
                return View(HomeViewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }


            //aRTiculateRepository.GetMockData(_db);

            
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

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            //Session.Clear();



            return RedirectToAction("Index");
        }
    }
}
