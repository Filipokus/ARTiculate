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
using Microsoft.AspNetCore.Authorization;

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
            List<Artist> artists = new List<Artist>();
            artists = await ARTiculateRepository.GetAllArtists();
            StudioOverviewViewModel viewModel = new StudioOverviewViewModel(artists);
            return View(viewModel);
        }

        
        public async Task<IActionResult> Studio(int id)       
        {            
            return View();
        }

        [Authorize]
        public async Task<IActionResult> MyStudio()
        {
            return View(await GetViewModelFromLoggedInArtist());
        }

        public async Task<MyStudioViewModel> GetViewModelFromLoggedInArtist()
        {
            ARTiculateUser user = await GetCurrentUserAsync();
             
            Artist artist = await ARTiculateRepository.GetArtistFromARTiculateUser(user);
            MyStudioViewModel viewModel = new MyStudioViewModel(artist);
            return viewModel;
        }

        private Task<ARTiculateUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);

        [Authorize]
        public async Task<IActionResult> UploadArtItem()
        {
            
                ARTiculateUser user = await GetCurrentUserAsync();
                Artist artist = await ARTiculateRepository.GetArtistFromARTiculateUser(user);

                ArtItemViewModel viewModel = new ArtItemViewModel
                {
                    Artist = artist
                };

                return View(viewModel);
          
        }

        
        [HttpPost]
        public async Task<IActionResult> UploadArtitem(ArtItemViewModel model)
        {
            ImageModel image = new ImageModel(model.ImageFile, model.ArtItem.Name);
            string URL = await ARTiulateServerRepository.UploadPictureToServer(image);
            model.ArtItem.Picture = URL;
            model.ArtItem.ArtistId = model.Artist.Id;
            
            await ARTiculateRepository.AddArtItem(model.ArtItem);
            return RedirectToAction("ArtItem", "Studios", new { id = model.ArtItem.Id });
        }

        [Authorize]
        public async Task<IActionResult> ArtItem(int id)
        {
            ArtItem artItem = await ARTiculateRepository.GetArtItem(id);

            ArtItemViewModel model = new ArtItemViewModel(artItem, null);

            return View(model);
        }

        [Authorize]
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

        [Authorize]
        public async Task<IActionResult> CreateExhibition()
        {
          
                ARTiculateUser user = await GetCurrentUserAsync();
                Artist artist = await ARTiculateRepository.GetArtistFromARTiculateUser(user);
                List<ArtItem> artItems = await ARTiculateRepository.GetArtItemsFromArtist(artist.Id);

                CreateExhibitionViewModel viewModel = new CreateExhibitionViewModel()
                {
                    ArtistId = artist.Id,
                    AllArtItems = artItems
                };

                return View(viewModel);
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateExhibition(CreateExhibitionViewModel input)
        {

            Exhibition exhibition = await ARTiculateRepository.AddExhibitionAsync(input.Exhibition);
            ARTiculateRepository.CreateArtist_Exhibition(exhibition.Id, input.ArtistId);

            //TODO binda checkboxar till nåt i vymodellen

            return RedirectToAction("Exhibition", "Exhibitions", new { id = exhibition.Id });
        }

        public IActionResult NotSignedIn()
        {
            return View();
        }
    }
}
