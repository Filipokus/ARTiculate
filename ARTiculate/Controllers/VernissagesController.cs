using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARTiculate.Data;
using ARTiculateDataAccessLibrary.Models;
using ARTiculate.Models;
using ARTiculateDataAccessLibrary.Models.DTO;

namespace ARTiculate.Controllers
{
    public class VernissagesController : Controller
    {
        
        private IARTiculateRepository ARTiculateRepository;

        public VernissagesController(IARTiculateRepository ARTiculateRepository)
        {
            this.ARTiculateRepository = ARTiculateRepository;
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
            var viewModel = await GetVernisageViewModel(ID);

            return View(viewModel);
        }

        public async Task<IActionResult> About(int ID)
        {
            var viewModel = await GetVernisageViewModel(ID);

            return View(viewModel);
        }

        

        public async Task<IActionResult> About(int ID)
        public async Task<IActionResult> CreateVernissage(Vernisage input)
        {
          
            input.Open = true;
          
            Vernisage vernissage = await ARTiculateRepository.AddVernisageAsync(input);
            return RedirectToAction("Vernissage", "Vernissages", new { id = vernissage.Id });
        }

        public IActionResult Create()
        {
            return View();
        }

        private async Task<VernisageViewModel> GetVernisageViewModel(int id)
        {
            Vernisage vernisage = await ARTiculateRepository.GetVernisage(ID);
            VernisageViewModel viewModel = new VernisageViewModel(vernisage);

            return View(viewModel);
        }
    }
}
