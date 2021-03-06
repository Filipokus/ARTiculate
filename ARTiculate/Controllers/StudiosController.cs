﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            Artist artist = await ARTiculateRepository.GetArtist(id);
            StudioViewModel viewModel = new StudioViewModel(artist);

            List<List<ArtItem>> listOfArtitemList = new List<List<ArtItem>>();
            List<Exhibition> exhibitions = await ARTiculateRepository.GetAllExhibitionsFromArtistAsync(artist.Id);
           
            //if an Artist has one or more exhibitions a list of artitems is created. 
            //The artitems are those that are in the exhibition. The list is then put in another list to be used in the view.
            //the list is a reflection of the list of exhibitions.
            if (exhibitions != null)
            {
                foreach (var exhibition in exhibitions)
                {
                    List<ArtItem> artItems = await ARTiculateRepository.GetArtItemsFromExhibition(exhibition.Id);
                    listOfArtitemList.Add(artItems);
                }

                viewModel.Exhibitions = exhibitions;
                viewModel.ListOfArtItemList = listOfArtitemList;
            }

            return View(viewModel);
        }        

        [Authorize]
        public async Task<IActionResult> MyStudio()
        {
            return View(await GetViewModelFromLoggedInArtist());
        }

        private async Task<MyStudioViewModel> GetViewModelFromLoggedInArtist()
        {
            ARTiculateUser user = await GetCurrentUserAsync();
            Artist artist = await ARTiculateRepository.GetArtistFromARTiculateUser(user);
            List<List<ArtItem>> ex = new List<List<ArtItem>>();
            List<Exhibition> exhibitions = await ARTiculateRepository.GetAllExhibitionsFromArtistAsync(artist.Id);

            //if an Artist has one or more exhibitions a list of artitems is created. 
            //The artitems are those that are in the exhibition. The list is then put in another list to be used in the view.
            //the list is a reflection of the list of exhibitions.
            if (exhibitions != null)
            {
                foreach (var exhibition in exhibitions)
                {
                    List<ArtItem> artItems = await ARTiculateRepository.GetArtItemsFromExhibition(exhibition.Id);
                    ex.Add(artItems);
                }
                MyStudioViewModel viewModel = new MyStudioViewModel(artist, exhibitions, ex);
                return viewModel;
            }
            //if the arist has no exhibitions a viewmodel with only the artist is created instead.
            else
            {
                MyStudioViewModel viewModel = new MyStudioViewModel(artist);
                return viewModel;
            }
        }

        //Fetches the logged in users information
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UploadArtitem(ArtItemViewModel model)
        {
            ImageModel image = new ImageModel(model.ImageFile, model.ArtItem.Name);
            string URL = await ARTiulateServerRepository.UploadPictureToServer(image);

            model.ArtItem.Picture = URL;
            model.ArtItem.ArtistId = model.Artist.Id;
            
            //when uploading an artitem it also populates the connections between the tags and artitems.
            ArtItem artItem = await ARTiculateRepository.AddArtItem(model.ArtItem);
            await ARTiculateRepository.AddArtItem_Tags(model.Tags, artItem.Id);

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
        public async Task<IActionResult> CreateVernissage()
        {
            ARTiculateUser user = await GetCurrentUserAsync();
            Artist artist = await ARTiculateRepository.GetArtistFromARTiculateUser(user);

            //gets all exhibitions that are not yet connected to a vernissage, these are used to connect a new venisage to.
            List<Exhibition> exhibitions = await ARTiculateRepository.GetAllExhibitionsWithOutVernissageFromArtist(artist.Id);
            Dictionary<int, Exhibition> allExhibitionsByArtistDictonary = new Dictionary<int, Exhibition>();

                foreach (Exhibition exhibition in exhibitions)
                {
                    allExhibitionsByArtistDictonary.Add(exhibition.Id, exhibition);
                }

                CreateVernissageViewModel viewModel = new CreateVernissageViewModel()
                {
                    AllExhibitionsByArtist = exhibitions,
                    AllExhibitionsByArtistDictonary = allExhibitionsByArtistDictonary,
                    ArtistId = artist.Id
                };

                return View(viewModel);
            
        }

        //the actual landing action that creates a vernissage in the database. then redirects to the newly created vernssiage. 
        [Authorize]
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
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateExhibition(CreateExhibitionViewModel input)
        {
            List<ArtItem> artItems = await ARTiculateRepository.GetArtItemsFromArtist(input.ArtistId);
            input.SelectedArtItems = ARTiulateServerRepository.GetSelectedArtItems(artItems, input.AllArtItemsByArtistBoolList);
            Exhibition exhibition = await ARTiculateRepository.AddExhibitionAsync(input.Exhibition);

            //creates connections between Exhibitions and corresponding connections
            Task artist_ExhibitionTask = ARTiculateRepository.CreateArtist_Exhibition(exhibition.Id, input.ArtistId);
            Task exhibition_ArtItemTask = ARTiculateRepository.CreateExhibition_ArtItemsAsync(input.SelectedArtItems, exhibition.Id);
            List<Task> tasks = new List<Task>() { artist_ExhibitionTask, exhibition_ArtItemTask };
            await Task.WhenAll(tasks);

            return RedirectToAction("Exhibition", "Exhibitions", new { id = exhibition.Id });
        }

    
    }
}
