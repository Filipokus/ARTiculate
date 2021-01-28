using System;
using System.Collections.Generic;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models
{
    public class Artist_Exhibition
    {
        public int ArtistId { get; set; }
        public int ExhibitionId { get; set; }
        public Artist Artist { get; set; }
        public Exhibition Exhibition { get; set; }
    }
}
