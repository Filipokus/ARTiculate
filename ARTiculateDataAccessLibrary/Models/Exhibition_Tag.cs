using System;
using System.Collections.Generic;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models
{
    public class Exhibition_Tag
    {
        public int TagId { get; set; }
        public int ExhibitionId { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<Exhibition> Exhibitions { get; set; } = new List<Exhibition>();

    }
}
