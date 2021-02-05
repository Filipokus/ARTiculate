using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "varchar(200)")]
        public string TagName { get; set; }

    }
}
