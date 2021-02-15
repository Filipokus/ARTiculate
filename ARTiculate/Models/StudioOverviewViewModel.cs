using ARTiculateDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Models
{
    public class StudioOverviewViewModel : BaseViewModel
    {
        public List<Artist> Artists { get; set; }
        public StudioOverviewViewModel(List<Artist> artists)
        {
            this.Artists = artists;
        }
    }
}
