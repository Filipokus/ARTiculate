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
            PopulateListWithArtistsForSelectedExhibition(exhibition);
        }

        private void PopulateListWithArtistsForSelectedExhibition(Exhibition exhibitionInput)
        {
            foreach (var exhibition in exhibitionInput.Artist_Exhibitions)
            {
                Artists.Add(exhibition.Artist);
            }
        }

    }
}
