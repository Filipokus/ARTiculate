using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARTiculate.Data;
using ARTiculateDataAccessLibrary.Models;
using ARTiculate.Models;
using ARTiculateDataAccessLibrary.Models.DTO;
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
            Exhibition exhibition = await ARTiculateRepository.GetExhibition(1);

            AllVernisagesViewModel allVernisagesViewModel = new AllVernisagesViewModel();
            List<Vernisage> vernisagesToCome = await ARTiculateRepository.GetAllVernisagesToCome();

            foreach (var vernisage in vernisagesToCome)
            {
                VernisageOverviewDTO vernisageSummary = new VernisageOverviewDTO(vernisage);
                allVernisagesViewModel.ArtistVernisageDTOs.Add(vernisageSummary);
            }

            return View(allVernisagesViewModel);
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

        //private async Task<VernisageViewModel> GetVernisageViewModel(int id)
        //{
        //    Vernisage vernisage = await ARTiculateRepository.GetVernisage(id);
        //    VernisageViewModel viewModel = new VernisageViewModel(vernisage);

        //    return viewModel;
        //}
    }
}
