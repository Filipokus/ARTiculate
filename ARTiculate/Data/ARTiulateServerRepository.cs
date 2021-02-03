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

        public ARTiulateServerRepository(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }
      
        public async Task <string> UploadPictureToServer(ImageModel imageModel)
        {
            string serverPath = hostEnvironment.ContentRootPath;
            string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            imageModel.ImageName = fileName = fileName + DateTime.Now.ToString("yyMMddhhmmssffff") + extension;
            string path = Path.Combine(serverPath + "/UploadedImages", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await imageModel.ImageFile.CopyToAsync(fileStream);
            }

            return "";
        }
    }
}
