using System;
using System.Collections.Generic;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models
{
    public class Exhibition
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public DateTime DateTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Open { get; set; }
        public List<Artist_Exhibition> Artist_Exhibitions { get; set; } = new List<Artist_Exhibition>();
        public List<Exhibition_Tag> Exhibition_Tags { get; set; } = new List<Exhibition_Tag>();
    
    }
}
