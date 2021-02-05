using System;
using System.Collections.Generic;
using System.Text;

namespace ARTiculateDataAccessLibrary.Models.DTO
{
    public class VernisageOverviewDTO
    {
        public VernisageOverviewDTO(Vernisage vernisage)
        {
            DateTime = vernisage.DateTime;
            Title = vernisage.Title;
            Id = vernisage.Id;

            foreach (var artist in vernisage.Artist_Vernisages)
            {
                FullName.Add(artist.Artist.Firstname + " " + artist.Artist.Lastname);
            }
        }

        public List<string> FullName { get; set; } = new List<string>();

        public DateTime DateTime { get; set; }

        public string Title { get; set; }

        public int Id { get; set; }
    }
}
