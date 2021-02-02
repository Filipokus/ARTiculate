using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Models
{
    public class ImageModel
    {
        public string Title { get; set; }    
        public string ImageName { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
