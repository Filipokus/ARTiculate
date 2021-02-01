using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace ARTiculateDataAccessLibrary.Models
{
    public class Exhibition
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Title { get; set; }

        [MaxLength(1024)]
        [Column(TypeName = "varchar(1024)")]
        public string Description { get; set; }

        public bool Open { get; set; }

        public List<Artist_Exhibition> Artist_Exhibitions { get; set; } = new List<Artist_Exhibition>();

        public List<Exhibition_Tag> Exhibition_Tags { get; set; } = new List<Exhibition_Tag>();
    
    }
}
