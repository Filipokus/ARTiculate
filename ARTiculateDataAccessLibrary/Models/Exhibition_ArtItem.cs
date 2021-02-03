using System;
using System.Collections.Generic;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models
{
    public class Exhibition_ArtItem
    {
        public int ExhibitionId { get; set; }
        public int ArtItemId { get; set; }
        public List<Exhibition> Exhibitions { get; set; } = new List<Exhibition>();
        public List<ArtItem> ArtItems { get; set; } = new List<ArtItem>();
    }
}
