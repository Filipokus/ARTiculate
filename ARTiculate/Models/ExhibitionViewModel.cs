using ARTiculateDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Models
{
    public class ExhibitionViewModel
    {
        public ExhibitionViewModel(Exhibition exhibition)
        {
            this.exhibition = exhibition;
        }

        public Exhibition exhibition { get; set; }


    }
}
