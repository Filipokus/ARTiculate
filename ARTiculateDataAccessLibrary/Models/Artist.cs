using System;
using System.Collections.Generic;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phonenumber { get; set; }
        public string Emailadress { get; set; }
        public string ProfilePicture { get; set; }
        public Link Link { get; set; }
        public List<ArtItem> ArtItems { get; set; } = new List<ArtItem>();
        public List<Vernisage> Vernisages { get; set; } = new List<Vernisage>();
        public List<Exhibition> Exhibitions { get; set; } = new List<Exhibition>();
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
