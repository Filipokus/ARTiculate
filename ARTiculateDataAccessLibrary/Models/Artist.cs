using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models
{
    public class Artist
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Firstname { get; set; }
        [MaxLength(100)]
        public string Lastname { get; set; }
        [MaxLength(20)]
        public string Phonenumber { get; set; }
        [MaxLength(50)]
        public string Emailadress { get; set; }
        [MaxLength(200)]
        public string ProfilePicture { get; set; }
        public Link Link { get; set; }
        public List<ArtItem> ArtItems { get; set; } = new List<ArtItem>();
        public List<Artist_Vernisage> Artist_Vernisages { get; set; } = new List<Artist_Vernisage>();
        public List<Artist_Exhibition> Artist_Exhibitions { get; set; } = new List<Artist_Exhibition>();
        public List<Artist_Tag> Artist_Tags { get; set; } = new List<Artist_Tag>();
    }
}
