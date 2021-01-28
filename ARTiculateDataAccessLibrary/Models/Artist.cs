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
        public List<Artist_Vernisage> Artist_Vernisages { get; set; } = new List<Artist_Vernisage>();
        public List<Artist_Exhibition> Artist_Exhibitions { get; set; } = new List<Artist_Exhibition>();
        public List<Artist_Tag> Artist_Tags { get; set; } = new List<Artist_Tag>();
    }
}
