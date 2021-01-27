using System;
using System.Collections.Generic;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models
{
    public class ArtItem_Tag
    {
        public int TagId { get; set; }
        public int ArtItemId { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<ArtItem> ArtItems { get; set; } = new List<ArtItem>();
}
}
