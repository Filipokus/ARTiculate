using ARTiculateDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Models
{
    public class StudioViewModel
    {
        public StudioViewModel(Artist artist)
        {
            this.Artist = artist;
        }

        public Artist Artist { get; set; }
    }
}
