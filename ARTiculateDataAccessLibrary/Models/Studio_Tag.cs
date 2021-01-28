using System;
using System.Collections.Generic;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models
{
    public class Studio_Tag
    {
        public int TagId { get; set; }
        public int StudioId { get; set; }
        public Tag Tag { get; set; }
        public Studio Studio { get; set; }
    }
}
