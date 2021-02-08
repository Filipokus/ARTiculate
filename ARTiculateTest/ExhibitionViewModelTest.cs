using ARTiculate.Models;
using ARTiculateDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ARTiculateTest
{
    public class ExhibitionViewModelTest
    {
        ExhibitionViewModel viewModel = new ExhibitionViewModel();

        [Fact]
        public void GetArtistsForSelectedExhibition_ShouldRetrunListOfArtists()
        {
            //Arrange
            Artist artist = new Artist
            {
                Id = 1,
                Firstname = "Test",
                Lastname = "Testsson"
            };

            Artist artistTwo = new Artist
            {
                Id = 2,
                Firstname = "Jest",
                Lastname = "Jestsson"
            };

            Artist_Exhibition artist_Exhibition = new Artist_Exhibition
            {
                Artist = artist
            };

            Artist_Exhibition artist_ExhibitionTwo = new Artist_Exhibition
            {
                Artist = artistTwo
            };

            List<Artist_Exhibition> artist_Exhibitions = new List<Artist_Exhibition>();
            artist_Exhibitions.Add(artist_Exhibition);
            artist_Exhibitions.Add(artist_ExhibitionTwo);

            Exhibition exhibition = new Exhibition
            {
                Artist_Exhibitions = artist_Exhibitions
            };

            List<Artist> expected = new List<Artist>();
            expected.Add(artist);
            expected.Add(artistTwo);

            //Act
            List<Artist> actual = viewModel.GetArtistsForSelectedExhibition(exhibition);

            //Assert
            Assert.True(actual != null);
            Assert.Equal(expected, actual);

        }
    }
}
