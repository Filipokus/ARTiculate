using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models
{
    public class Link
    {
        [Key]
        public int ArtistId { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "varchar(500)")]
        public string Instagram { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "varchar(500)")]
        public string Pinterest { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "varchar(500)")]
        public string Patreon { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "varchar(500)")]
        public string Facebook { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "varchar(500)")]
        public string FlickR { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "varchar(500)")]
        public string Linkedin { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "varchar(500)")]
        public string Website { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "varchar(500)")]
        public string Optional { get; set; }
    }
}
