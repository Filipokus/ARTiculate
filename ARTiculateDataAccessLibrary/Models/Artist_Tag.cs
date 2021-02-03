using System;
using System.Collections.Generic;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models
{
    public class Artist_Tag
    {
        public int TagId { get; set; }
        public int ArtistId { get; set; }
        public Tag Tag { get; set; }
        public Artist Artist { get; set; }
    }
}
