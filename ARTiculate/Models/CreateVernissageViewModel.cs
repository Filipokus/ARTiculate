using ARTiculateDataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Models
{
    public class CreateVernissageViewModel
    {
        public CreateVernissageViewModel()
        {

        }

        public CreateVernissageViewModel(Vernisage vernissage, IFormFile imageFile)
        {
            Vernissage = vernissage;
            ImageFile = imageFile;
            FileName = vernissage.Title;

        }

        public IFormFile ImageFile { get; set; }

        public string FileName { get; set; }

        public Vernisage Vernissage { get; set; }

        public List<Exhibition> AllExhibitionsByArtist { get; set; }

        [DisplayName("Select an exhibition")]
        public Exhibition SelectedExhibition { get; set; }
        public Dictionary<int, Exhibition> AllExhibitionsByArtistDictonary { get; set; }
        public int SelectedExhibitionId { get; set; }
    }
}
