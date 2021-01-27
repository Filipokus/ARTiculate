using System;
using System.Collections.Generic;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models
{
    public class Vernisage
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public DateTime DateTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Open { get; set; }
        public List<Artist> Artists { get; set; } = new List<Artist>();
        public List<Tag> Tags { get; set; } = new List<Tag>();


    }
}
