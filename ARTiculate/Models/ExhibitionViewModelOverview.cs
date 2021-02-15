using ARTiculateDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Models
{
    public class ExhibitionViewModelOverview: BaseViewModel
    {
        public Exhibition Exhibition { get; set; }

        public ExhibitionViewModelOverview(Exhibition exhibition)
        {
            Exhibition = exhibition;
        }
    }
}
