using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models
{
    public class ArtItem
    {
        public int Id { get; set; }

        public int ArtistId { get; set; }

        [MaxLength(100)]
        public string Picture { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [MaxLength(1000)]
        [Column(TypeName = "varchar(1000)")]
        public string Description { get; set; }

        [Required]
        public int Height { get; set; }

        [Required]
        public int Width { get; set; }

        public int Depth { get; set; }

        public bool Open { get; set; }

        public List<ArtItem_Tag> ArtItem_Tags { get; set; } = new List<ArtItem_Tag>();


    }
}
