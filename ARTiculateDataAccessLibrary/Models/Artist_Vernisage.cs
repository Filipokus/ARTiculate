using System;
using System.Collections.Generic;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models
{
    public class Artist_Vernisage
    {
        public int ArtistId { get; set; }
        public int VernisageId { get; set; }
        public Artist Artist { get; set; }
        public Vernisage Vernisage { get; set; }
    }
}
