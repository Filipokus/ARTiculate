using ARTiculateDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Models
{
    public class ExhibitionViewModelOverview
    {
        public Exhibition Exhibition { get; set; }
        public List<ArtItem> Artitems { get; set; }

        public ExhibitionViewModelOverview(Exhibition exhibition, List<ArtItem> artItems)
        {
            Exhibition = exhibition;
            Artitems = artItems;
        }

        
       
    }
}
