using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARTiculate.Data;
using ARTiculateDataAccessLibrary.Models;
using ARTiculate.Models;
using Microsoft.AspNetCore.Identity;
using ARTiculate.Areas.Identity.Data;

namespace ARTiculate.Controllers
{
    public class VernissagesController : Controller
    {
        
        private IARTiculateRepository ARTiculateRepository;
        private UserManager<ARTiculateUser> userManager;

        public VernissagesController(
            IARTiculateRepository ARTiculateRepository,
            UserManager<ARTiculateUser> userManager)
        {
            this.ARTiculateRepository = ARTiculateRepository;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {           
            try
            {
                Task<List<Vernisage>> futureVernisages = ARTiculateRepository.GetAllVernisagesToCome();
                Task<List<Vernisage>> liveVernisages = ARTiculateRepository.GetLiveVernisages();
                List<Task> tasks = new List<Task>() { futureVernisages, liveVernisages };
                await Task.WhenAll(tasks);             

                VernisagesViewModel VernisagesViewModel = new VernisagesViewModel(futureVernisages.Result, liveVernisages.Result);
                return View(VernisagesViewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<IActionResult> Vernissage(int ID)
        {
            Vernisage vernisage = await ARTiculateRepository.GetVernisage(ID);
            VernisageViewModel viewModel;

            if (User.Identity.IsAuthenticated)
            {
                ARTiculateUser user = await GetCurrentUserAsync();
                Artist artist = new Artist();
                artist = ARTiculateRepository.CreateArtistFromARTiculateUser(user);
                viewModel = new VernisageViewModel(vernisage, artist);
            }
            else
            {
                viewModel = new VernisageViewModel(vernisage);
            }

            return View(viewModel);
        }

        private Task<ARTiculateUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);


        public async Task<IActionResult> About(int ID)
        {
            Vernisage vernisage = await ARTiculateRepository.GetVernisage(ID);
            AboutVernisageViewModel viewModel = new AboutVernisageViewModel(vernisage);

            return View(viewModel);
        }
    }
}
