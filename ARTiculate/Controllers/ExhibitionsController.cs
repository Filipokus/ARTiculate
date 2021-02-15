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

        public async Task<IActionResult> Index()
        {
            try
            {
                List<Exhibition> exhibition = await ARTiculateRepository.GetExhibitionsFromDbOrderedByDate();
                ExhibitionViewModel exhibitionViewModel = new ExhibitionViewModel(exhibition);
                
                return View(exhibitionViewModel);                 
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home");
            }
            //List<Exhibition> exhibition = await ARTiculateRepository.GetExhibitionsFromDbOrderedByDate();
            //ExhibitionViewModel exhibitionViewModel = new ExhibitionViewModel(exhibition);
            //if (exhibitionViewModel.Exhibitions.Count > 0  && exhibitionViewModel.NewlyAddedExhibitions.Count > 0) //&& exhibitionViewModel.ExhibitionsByTagName.Count > 0)
            //{
            //    return View(exhibitionViewModel);
            //}
            //else
            //{
            //    return RedirectToAction("Error", "Home");
            //}
        }

        public async Task<IActionResult> Exhibition(int ID)
        {
            Exhibition exhibitionTask = await ARTiculateRepository.GetExhibition(ID);
            List<ArtItem> artItemTask = await ARTiculateRepository.GetArtItemsFromExhibition(ID);
                      
            ExhibitionViewModelOverview viewModel = new ExhibitionViewModelOverview(exhibitionTask, artItemTask);

            return View(viewModel);
        }
    }
}
