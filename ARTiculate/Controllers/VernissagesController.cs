using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARTiculate.Data;
using ARTiculateDataAccessLibrary.Models;
using ARTiculate.Models;

namespace ARTiculate.Controllers
{
    public class VernissagesController : Controller
    {
        
        private IARTiculateRepository ARTiculateRepository;

        public VernissagesController(IARTiculateRepository ARTiculateRepository)
        {
            this.ARTiculateRepository = ARTiculateRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Vernissage(int ID)
        {
            
            Vernisage vernisage = await ARTiculateRepository.GetVernisage(ID);

            VernisageViewModel viewModel = new VernisageViewModel(vernisage);
            
            return View(viewModel);
        }

        public async void Vernissage(Vernisage x)
        {
            x.Open = true;
            x.DateTime = new DateTime(2020 - 02 - 04);
            Vernisage vernisage = await ARTiculateRepository.AddVernisageAsync(x);


            Vernissage(vernisage.Id);


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
