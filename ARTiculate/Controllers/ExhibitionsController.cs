using ARTiculate.Data;
using ARTiculate.Models;
using ARTiculateDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Controllers
{
    public class ExhibitionsController : Controller
    {
        private IARTiculateRepository ARTiculateRepository;

        public ExhibitionsController(IARTiculateRepository ARTiculateRepository)
        {
            this.ARTiculateRepository = ARTiculateRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Exhibtion(int id)
        {
            Exhibition exhibition = await ARTiculateRepository.GetExhibition(id);
            ExhibitionViewModel viewModel = new ExhibitionViewModel(exhibition);

            return View(viewModel);
        }
    }
}
