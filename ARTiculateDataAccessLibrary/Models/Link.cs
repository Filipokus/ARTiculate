using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models
{
    public class Link
    {
        [Key]
        public int ArtistId { get; set; }
        public string Instagram { get; set; }
        public string Pinterest { get; set; }
        public string Patreon { get; set; }
        public string Facebook { get; set; }
        public string FlickR { get; set; }
        public string Linkedin { get; set; }
        public string Website { get; set; }
        public string Optional { get; set; }
    }
}
