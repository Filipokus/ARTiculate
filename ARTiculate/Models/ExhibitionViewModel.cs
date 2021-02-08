using ARTiculateDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Models
{
    public class ExhibitionViewModel
    {
        public Exhibition Exhibition { get; set; }
        public List<Artist> Artists { get; set; } = new List<Artist>();

        public ExhibitionViewModel(Exhibition exhibition)
        {
            this.Exhibition = exhibition;
            Artists = GetArtistsForSelectedExhibition(exhibition);
        }

        public ExhibitionViewModel()
        {

        }

        public List<Artist> GetArtistsForSelectedExhibition(Exhibition exhibitionInput)
        {
            List<Artist> artists = new List<Artist>();

            foreach (var exhibition in exhibitionInput.Artist_Exhibitions)
            {
                artists.Add(exhibition.Artist);
            }

            return artists;
        }

    }
}
