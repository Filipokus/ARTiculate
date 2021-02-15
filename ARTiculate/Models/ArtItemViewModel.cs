using ARTiculateDataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Models
{
    public class ArtItemViewModel
    {
        public ArtItemViewModel()
        {

        }

        public ArtItemViewModel(ArtItem artItem, IFormFile imageFile=null)
        {
            ArtItem = artItem;
            ImageFile = imageFile;
            FileName = artItem.Name;

        }

        public IFormFile ImageFile { get; set; }

        public string FileName { get; set; }

        public ArtItem ArtItem { get; set; }

        public Artist Artist { get; set; }

        public int ArtistId { get; set; }
        public string Tags { get; set; }
    }
}
