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
        public List<Artist_Vernisage> Artist_Vernisages { get; set; } = new List<Artist_Vernisage>();
        public List<Vernisage_Tag> Vernisage_Tags { get; set; } = new List<Vernisage_Tag>();
    }
}
