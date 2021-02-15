using ARTiculateDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Models
{
    public class HomeViewModel
    {
        public HomeViewModel(List<Vernisage> futureVernisages=null, List<Vernisage> liveVernisages=null,List<Exhibition> exhibitions=null, List<Artist> artists=null )
        {
            FutureVernisages = futureVernisages;
            LiveVernisages = liveVernisages;
            Exhibitions = exhibitions;
            Artists = artists;
        }

        public List<Vernisage> FutureVernisages { get; set; } = new List<Vernisage>();
        public List<Vernisage> LiveVernisages { get; set; } = new List<Vernisage>();
        public List<Exhibition> Exhibitions { get; set; } = new List<Exhibition>();
        public List<Artist> Artists { get; set; } = new List<Artist>();
    }
}
