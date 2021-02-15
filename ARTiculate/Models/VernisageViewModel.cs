using ARTiculateDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Models
{
    public class VernisageViewModel : BaseViewModel
    {
        public Vernisage Vernisage { get; set; }
        public Artist Artist { get; set; }

        public VernisageViewModel(Vernisage vernisage, Artist artist)
        {
            this.Vernisage = vernisage;
            this.Artist = artist;
        }

        public VernisageViewModel(Vernisage vernisage)
        {
            this.Vernisage = vernisage;
        }
       
    } 
}
