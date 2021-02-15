using System;
using System.Collections.Generic;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models
{
    public class Exhibition_Tag
    {
        public int TagId { get; set; }
        public int ExhibitionId { get; set; }
        public Tag Tag { get; set; }
        public Exhibition Exhibition { get; set; }

        public override string ToString()
        {
            return $"Exhibition: {Exhibition.Title} - Tag: {Tag.TagName}";
        }


    }
}
