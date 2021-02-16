using ARTiculateDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Models
{
    public class StudioViewModel
    {
        public Artist Artist { get; set; }

        public List<Exhibition> Exhibitions { get; set; }

        public List<List<ArtItem>> ListOfArtItemList { get; set; }

        public StudioViewModel(Artist artist)
        {
            Artist = artist;
        }
    }
}
