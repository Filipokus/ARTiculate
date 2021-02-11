using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using ARTiculate.Data;
using Microsoft.AspNetCore.Http;
using ARTiculate.Models;
using ARTiculateDataAccessLibrary.Models;

namespace ARTiculate.Controllers
{
    public class StudiosController : Controller
    {

        private IARTiulateServerRepository ARTiulateServerRepository;
        private IARTiculateRepository ARTiculateRepository;


        public StudiosController(IARTiulateServerRepository ARTiculateServerRepository, IARTiculateRepository ARTiculateRepository)
        {
            this.ARTiulateServerRepository = ARTiculateServerRepository;
            this.ARTiculateRepository = ARTiculateRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Studio(/*id*/)
        {
            /*id<--- användas vid identifiering av studio*/
            return View();
        }

        public IActionResult UploadArtItem(/*id*/)
        {
            /*id<--- användas vid identifiering av studio*/
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadArtitem(ArtItemViewModel model)
        {
            ImageModel image = new ImageModel(model.ImageFile, model.ArtItem.Name);
            string URL = await ARTiulateServerRepository.UploadPictureToServer(image);
            model.ArtItem.Picture = URL;

            //TODO: Set this value from Identity / identifiering av studio
            model.ArtItem.ArtistId = 1;
            
            await ARTiculateRepository.AddArtItem(model.ArtItem);
            return RedirectToAction("ArtItem", "Studios", new { id = model.ArtItem.Id });
        }

        public async Task<IActionResult> ArtItem(int id)
        {
            ArtItem artItem = await ARTiculateRepository.GetArtItem(id);

            ArtItemViewModel model = new ArtItemViewModel(artItem, null);

            return View(model);
        }

        public async Task<IActionResult> CreateVernissage(int id)
        {
            List<Exhibition> exhibitions = await ARTiculateRepository.GetAllExhibitionsWithOutVernissageFromArtist(id);
            Dictionary<int, Exhibition> allExhibitionsByArtistDictonary = new Dictionary<int, Exhibition>();

            foreach (Exhibition exhibition in exhibitions)
            {
                allExhibitionsByArtistDictonary.Add(exhibition.Id, exhibition);
            }

            CreateVernissageViewModel viewModel = new CreateVernissageViewModel()
            {
                AllExhibitionsByArtist = exhibitions,
                AllExhibitionsByArtistDictonary = allExhibitionsByArtistDictonary,
                ArtistId = id
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVernissage(CreateVernissageViewModel input)
        {
            ImageModel image = new ImageModel(input.ImageFile, input.Vernissage.Title);
            string URL = await ARTiulateServerRepository.UploadPictureToServer(image);

            input.Vernissage.Duration = ARTiulateServerRepository.CalculateDuration(input.Vernissage.DateTime, input.EndTime);
            input.Vernissage.Poster = URL;
            input.Vernissage.ExhibitionId = input.SelectedExhibitionId;
            
            Vernisage vernissage = await ARTiculateRepository.AddVernisageAsync(input.Vernissage);
            ARTiculateRepository.CreateArtist_Vernisage(vernissage.Id, input.ArtistId);
            
            return RedirectToAction("Vernissage", "Vernissages", new { id = vernissage.Id });
        }

        public async Task<IActionResult> CreateExhibition(int id)
        {

            //TODO Set this value from Identity / identifiering av studio

            CreateExhibitionViewModel viewModel = new CreateExhibitionViewModel()
            {
                ArtistId = id
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExhibition(CreateExhibitionViewModel input)
        {

            Exhibition exhibition = await ARTiculateRepository.AddExhibitionAsync(input.Exhibition);
            ARTiculateRepository.CreateArtist_Exhibition(exhibition.Id, input.ArtistId);

            return RedirectToAction("Exhibition", "Exhibitions", new { id = exhibition.Id });
        }
    }
}
