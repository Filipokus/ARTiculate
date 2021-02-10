using ARTiculateDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Models
{
    public class CreateExhibitionViewModel
    {
        public int ArtistId { get; set; }

        public Exhibition Exhibition { get; set; }

        public List<ArtItem> ArtItems { get; set; }

        public List<Tag> ExhibitionTags { get; set; }
    }
}
