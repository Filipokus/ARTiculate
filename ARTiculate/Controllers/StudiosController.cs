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
using Microsoft.AspNetCore.Identity;
using ARTiculate.Areas.Identity.Data;

namespace ARTiculate.Controllers
{
    public class StudiosController : Controller
    {

        private IARTiulateServerRepository ARTiulateServerRepository;
        private IARTiculateRepository ARTiculateRepository;
        private UserManager<ARTiculateUser> userManager;

        public StudiosController(
            IARTiulateServerRepository ARTiculateServerRepository, 
            IARTiculateRepository ARTiculateRepository,
            UserManager<ARTiculateUser> userManager
            )
        {
            this.ARTiulateServerRepository = ARTiculateServerRepository;
            this.ARTiculateRepository = ARTiculateRepository;
            this.userManager = userManager;

        }

        public async Task<IActionResult> Index()
        {
        
            return View();
        }

        public  IActionResult Studio()       
        {            
            return View(GetViewModelFromLoggedInArtist());
        }

        public async Task<StudioViewModel> GetViewModelFromLoggedInArtist()
        {
            ARTiculateUser user = await GetCurrentUserAsync();
            Artist artist = new Artist();
            artist = ARTiculateRepository.CreateArtistFromARTiculateUser(user);
            StudioViewModel viewModel = new StudioViewModel(artist);
            return viewModel;
        }

        private Task<ARTiculateUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);

      
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
            List<Exhibition> exhibitions = await ARTiculateRepository.GetAllExhibitionsFromArtistAsync(id);
            Dictionary<int, Exhibition> allExhibitionsByArtistDictonary = new Dictionary<int, Exhibition>();

            //TODO: Koppla den metod som hämtar enbart exhibitions som saknar vernissage

            foreach (Exhibition exhibition in exhibitions)
            {
                allExhibitionsByArtistDictonary.Add(exhibition.Id, exhibition);
            }

            CreateVernissageViewModel viewModel = new CreateVernissageViewModel()
            {
                AllExhibitionsByArtist = exhibitions,
                AllExhibitionsByArtistDictonary = allExhibitionsByArtistDictonary
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVernissage(CreateVernissageViewModel input)
        {
            ImageModel image = new ImageModel(input.ImageFile, input.Vernissage.Title);
            string URL = await ARTiulateServerRepository.UploadPictureToServer(image);
            input.Vernissage.Poster = URL;
            input.Vernissage.ExhibitionId = input.SelectedExhibitionId;

            Vernisage vernissage = await ARTiculateRepository.AddVernisageAsync(input.Vernissage);
            return RedirectToAction("Vernissage", "Vernissages", new { id = vernissage.Id });
        }

        //TODO: CreateExhibition

        //public async Task<IActionResult> CreateExhibition(int id)
        //{
        //    List<Exhibition> exhibitions = await ARTiculateRepository.GetAllExhibitionsFromArtistAsync(id);

        //    CreateVernissageViewModel viewModel = new CreateVernissageViewModel()
        //    {
        //        AllExhibitionsByArtist = exhibitions
        //    };

        //    return View(viewModel);
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateExhibition(CreateVernissageViewModel input)
        //{
        //    //TODO: Set this value from Identity / identifiering av studio
        //    model.ArtItem.ArtistId = 1;

        //    await ARTiculateRepository.AddArtItem(model.ArtItem);
        //    return RedirectToAction("ArtItem", "Studios", new { id = model.ArtItem.Id });
        //}
    }
}
