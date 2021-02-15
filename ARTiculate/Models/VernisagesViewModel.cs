using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARTiculateDataAccessLibrary.Models;

namespace ARTiculate.Models
{
    public class VernisagesViewModel : BaseViewModel
    {
        public VernisagesViewModel()
        {

        }
        public VernisagesViewModel(List<Vernisage> futureVernisages, List<Vernisage> liveVernisages)
        {
            FutureVernisages = futureVernisages;
            LiveVernisages = liveVernisages;
        }

        public List<Vernisage> FutureVernisages { get; set; } = new List<Vernisage>();

        public List<Vernisage> LiveVernisages { get; set; } = new List<Vernisage>();
    }

}
