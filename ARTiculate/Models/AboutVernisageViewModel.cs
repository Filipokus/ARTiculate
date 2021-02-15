using ARTiculateDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Models
{
    public class AboutVernisageViewModel: BaseViewModel
    {
        public Vernisage Vernisage { get; set; }
        public List<Artist> ListOfArtists { get; set; } = new List<Artist>();

        public AboutVernisageViewModel(Vernisage vernisage)
        {
            this.Vernisage = vernisage;
            PopulateListOfArtists(vernisage);
        }

        private void PopulateListOfArtists(Vernisage vernisage)
        {
            foreach (var x in vernisage.Artist_Vernisages)
            {
                ListOfArtists.Add(x.Artist);
            }
        }
    }
}
