using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARTiculateDataAccessLibrary.Models.DTO;

namespace ARTiculate.Models
{
    public class AllVernisagesViewModel
    {
        public AllVernisagesViewModel()
        {

        }
        public AllVernisagesViewModel(List<VernisageOverviewDTO> artistVernisageDTOs)
        {
            ArtistVernisageDTOs = artistVernisageDTOs;
        }

        public List<VernisageOverviewDTO> ArtistVernisageDTOs { get; set; } = new List<VernisageOverviewDTO>();
    }
}
