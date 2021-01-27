using System;
using System.Collections.Generic;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models
{
    public class Studio
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public bool Open { get; set; }
        public Artist Artist { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
