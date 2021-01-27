using System;
using System.Collections.Generic;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models
{
    public class Vernisage_Tag
    {
        public int TagId { get; set; }
        public int VernisageId { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<Vernisage> Vernisages { get; set; } = new List<Vernisage>();
    }
}
