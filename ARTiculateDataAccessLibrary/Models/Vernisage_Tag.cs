using System;
using System.Collections.Generic;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models
{
    public class Vernisage_Tag
    {
        public int TagId { get; set; }

        public int VernisageId { get; set; }

        public Tag Tag { get; set; }

        public Vernisage Vernisage { get; set; }
    }
}
