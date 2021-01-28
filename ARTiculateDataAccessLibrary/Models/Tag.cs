using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string TagName { get; set; }

    }
}
