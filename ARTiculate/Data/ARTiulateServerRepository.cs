using ARTiculate.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Data
{
    public class ARTiulateServerRepository : IARTiulateServerRepository
    {
        
        private IWebHostEnvironment hostEnvironment;

        #region CONSTRUCT
        public ARTiulateServerRepository(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }
        /// <summary>
        /// Ctor for test class to avoid an empty ctor
        /// </summary>
        /// <param name="test"></param>
        public ARTiulateServerRepository(string test) 
        {
            
        }
        #endregion

        public async Task <string> UploadPictureToServer(ImageModel imageModel)
        {
            string serverPath = hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(imageModel.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            imageModel.FileName = fileName = fileName + DateTime.Now.ToString("yyMMddhhmmssffff") + extension;
            string path = Path.Combine(serverPath + "/UploadedImages", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await imageModel.ImageFile.CopyToAsync(fileStream);
            }
            int skippableURL = serverPath.Length;
            string newURL = path.Substring(skippableURL);
            return "~" + newURL;
        }


    }
}
