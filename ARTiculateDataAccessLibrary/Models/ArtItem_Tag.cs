using System;
using System.Collections.Generic;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models
{
    public class ArtItem_Tag
    {
        public int TagId { get; set; }
        public int ArtItemId { get; set; }
        public Tag Tag { get; set; }
        public ArtItem ArtItem { get; set; }
}
}
