using ARTiculateDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Models
{
    public class MyStudioViewModel : BaseViewModel
    {
        public MyStudioViewModel(Artist artist)
        {
            this.Artist = artist;
        }

        public Artist Artist { get; set; }
    }
}
