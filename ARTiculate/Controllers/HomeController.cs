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

                HomeViewModel homeViewModel = new HomeViewModel(randomId, futureVernisages, liveVernisages, exhibitions, artists);

                if (User.Identity.IsAuthenticated)
                {
                    ARTiculateUser user = await userManager.GetUserAsync(HttpContext.User);
                    Artist loggedInArtist = await aRTiculateRepository.GetArtistFromARTiculateUser(user);
                    homeViewModel.LoggedInArtist = "Welcome " + loggedInArtist.ToString();
                }

                //homeViewModel.posterstrings = await aRTiculateRepository.GetRandomPosters(exhibitions);

                //ta emot list<exhibitions>
                //return list<string> med posterURLs

                return View(homeViewModel);
                //Task<List<Vernisage>> futureVernisages = aRTiculateRepository.GetAllVernisagesToCome();
                //Task<List<Vernisage>> liveVernisages = aRTiculateRepository.GetLiveVernisages();
                //Task<List<Exhibition>> exhibitions = aRTiculateRepository.GetAllExhibitionsOrderedByDate();
                //Task<List<Artist>> artists = aRTiculateRepository.GetAllArtists();
                //List<Task> tasks = new List<Task>() {futureVernisages,liveVernisages,exhibitions,artists };
                //await Task.WhenAll(tasks);

                //HomeViewModel HomeViewModel = new HomeViewModel(futureVernisages.Result, liveVernisages.Result, exhibitions.Result, artists.Result);
                //return View(HomeViewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }


            //aRTiculateRepository.GetMockData(_db);
            //BaseViewModel viewModel = new BaseViewModel(id);

            //return View(viewModel);
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
