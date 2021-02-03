using ARTiculateDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Models
{
    public class VernisageViewModel
    {
        public VernisageViewModel(Vernisage vernisage)
        {
            this.Vernisage = vernisage;
        }

        public Vernisage Vernisage { get; set; }
    }
}
