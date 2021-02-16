using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Models
{
    public class ImageModel
    {
        public ImageModel(IFormFile imageFile, string filename)
        {
            ImageFile = imageFile;
            FileName = filename;
        }
        public IFormFile ImageFile { get; set; }

        public string FileName { get; set; }
    }
}
