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

            AllVernisagesViewModel allVernisagesViewModel = new AllVernisagesViewModel();
            List<Vernisage> vernisagesToCome = await ARTiculateRepository.VernisagesToCome();

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

            VernisageViewModel viewModel = new VernisageViewModel(vernisage);
            
            return View(viewModel);
        }

        public async Task<IActionResult> CreateVernissage(Vernisage x)
        {
          
            x.Open = true;
          
            int id = await ARTiculateRepository.AddVernisageAsync(x);
            return RedirectToAction("Vernissage", "Vernissages", new { id = id });


        }

        public async Task<IActionResult> About(int ID)
        {
            Vernisage vernisage = await ARTiculateRepository.GetVernisage(ID);
            VernisageViewModel viewModel = new VernisageViewModel(vernisage);

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
