using ARTiculateDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Models
{
    public class MyStudioViewModel
    {
        public MyStudioViewModel(Artist artist, List<Exhibition> exhibitions, List<List<ArtItem>> ex)
        {
            this.Artist = artist;
            this.Exhibitions = exhibitions;
            this.ExhibitionArtItems = ex;
        }

        public MyStudioViewModel(Artist artist)
        {
            this.Artist = artist;
        }

        public Artist Artist { get; set; }
        public List<Exhibition> Exhibitions { get; set; }
        public List<List<ArtItem>> ExhibitionArtItems { get; set; }
    }
}
