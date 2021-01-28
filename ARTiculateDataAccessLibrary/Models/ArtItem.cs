using System;
using System.Collections.Generic;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models
{
    public class ArtItem
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public string Picture { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string Depth { get; set; }
        public bool Open { get; set; }
        public List<ArtItem_Tag> ArtItem_Tags { get; set; } = new List<ArtItem_Tag>();


    }
}
