using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using ARTiculate.Data;
using Microsoft.AspNetCore.Http;
using ARTiculate.Models;

namespace ARTiculate.Controllers
{
    public class StudiosController : Controller
    {

        private IARTiulateServerRepository ARTiulateServerRepository;
        

        public StudiosController(IARTiulateServerRepository ARTiculateServerRepository)
        {
            this.ARTiulateServerRepository = ARTiculateServerRepository;
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
        public async Task<IActionResult> UploadArtitem(string title, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                ImageModel model = new ImageModel();
                model.ImageName = title;
                model.Title = title;
                model.ImageFile = imageFile;
                string URL = await ARTiulateServerRepository.UploadPictureToServer(model);

            }
            return (IActionResult)View();

        }
    }
}
