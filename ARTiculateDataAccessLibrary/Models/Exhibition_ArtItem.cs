using System;
using System.Collections.Generic;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models
{
    public class Exhibition_ArtItem
    {
        public int ExhibitionId { get; set; }
        public int ArtItemId { get; set; }
        public Exhibition Exhibitions { get; set; } 
        public ArtItem ArtItems { get; set; } 
    }
}
