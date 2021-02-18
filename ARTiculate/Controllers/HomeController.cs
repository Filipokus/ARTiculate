using ARTiculate.Models;
using ARTiculateDataAccessLibrary.DataAccess;
using ARTiculateDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using ARTiculate.Data;
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
        private UserManager<ARTiculateUser> userManager;
        

        public HomeController(ILogger<HomeController> logger, 
            ArtistContext db, 
            IARTiculateRepository aRTiculateRepository, 
            SignInManager<ARTiculateUser> signInManager,
            UserManager<ARTiculateUser> userManager
           )
        {
            _logger = logger;
            _db = db;
            this.aRTiculateRepository = aRTiculateRepository;
            _signInManager = signInManager;
            this.userManager = userManager;

        }

        public async Task<IActionResult> Index()
        {
            try
            {
                int randomId = await aRTiculateRepository.RandomizedExhibitionId();
                List<Vernisage> futureVernisages =await aRTiculateRepository.GetAllVernisagesToCome();
                List<Vernisage> liveVernisages = await aRTiculateRepository.GetLiveVernisages();
                List<Exhibition> exhibitions = await aRTiculateRepository.GetAllExhibitionsOrderedByDate();
                List<Artist> artists = await aRTiculateRepository.GetAllArtists();

                //There should be a tasklist here, but it wont work with the repo
                HomeViewModel homeViewModel = new HomeViewModel(randomId, futureVernisages, liveVernisages, exhibitions, artists);

                //checks if user is logged in, if that is the case. Creates a welcome message for the logged in artist.
                if (User.Identity.IsAuthenticated)
                {
                    ARTiculateUser user = await userManager.GetUserAsync(HttpContext.User);
                    Artist loggedInArtist = await aRTiculateRepository.GetArtistFromARTiculateUser(user);
                    homeViewModel.LoggedInArtist = "Welcome " + loggedInArtist.ToString();
                }
                             

                return View(homeViewModel);
           
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }      
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
            return RedirectToAction("Index");
        }
    }
}
