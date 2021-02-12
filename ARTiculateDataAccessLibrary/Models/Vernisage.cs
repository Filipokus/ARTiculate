using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models
{
    public class Vernisage
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public double Duration { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Title { get; set; }

        [MaxLength(1024)]
        [Column(TypeName = "varchar(1024)")]
        public string Description { get; set; }

        [Required]
        [MaxLength(1000)]
        [Column(TypeName = "varchar(1000)")]
        public string LiveLink { get; set; }

        public bool Open { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Poster { get; set; }

        public int ExhibitionId { get; set; }

        public Exhibition Exhibition { get; set; }

        public List<Artist_Vernisage> Artist_Vernisages { get; set; } = new List<Artist_Vernisage>();

        public List<Vernisage_Tag> Vernisage_Tags { get; set; } = new List<Vernisage_Tag>();
    }
}
