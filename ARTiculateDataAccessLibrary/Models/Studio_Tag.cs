using System;
using System.Collections.Generic;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models
{
    public class Studio_Tag
    {
        public int TagId { get; set; }
        public int StudioId { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<Studio> Studios { get; set; } = new List<Studio>();
    }
}
