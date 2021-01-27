using System;
using System.Collections.Generic;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models
{
    public class Artist_Tag
    {
        public int TagId { get; set; }
        public int ArtistId { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<Artist> Artists { get; set; } = new List<Artist>();
    }
}
