using ARTiculateDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Models
{
    public class StudioViewModel : BaseViewModel
    {
        public Artist Artist { get; set; }

        public StudioViewModel(Artist artist)
        {
            Artist = artist;
        }
    }
}
