using System;
using System.Collections.Generic;
using System.Text;
using ARTiculate.Data;
using Xunit;
using ARTiculate.Models;
using System.IO;
using ARTiculateDataAccessLibrary.Models;

namespace ARTiculateTest
{
    public class ARTiculateServerRepoTest
    {
        ARTiulateServerRepository repo = new ARTiulateServerRepository("test");

        [Theory]
        [InlineData ("2008-03-15 09:00:00", "2008-03-15 11:30:00",  2.5) ]
        [InlineData("2008-03-15, 23:00:00", "2008-03-16, 01:00:00", 2)]
        public void CalculateDuration_ShouldReturnDouble(string start, string end, double expected)
        {
            //Arrange
            DateTime startTime = DateTime.Parse(start);
            DateTime endTime = DateTime.Parse(end);

            //Act
            double actual = repo.CalculateDuration(startTime, endTime);

            //Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void GetSelectedArtItems_ShouldReturnListOfArtItems()
        {
            //Arrange
            ArtItem artPiece1 = new ArtItem 
            {
                Id = 1
            };

            ArtItem artPiece2 = new ArtItem
            {
                Id = 2
            };

            ArtItem artPiece3 = new ArtItem
            {
                Id = 3
            };

            List<bool> theSelectedArtItems = new List<bool>
            {
                true,
                false,
                true
            };

            List<ArtItem> allArtItems = new List<ArtItem> 
            {
                artPiece1,
                artPiece2,
                artPiece3
            };

            List<ArtItem> expected = new List<ArtItem> 
            {
                artPiece1,
                artPiece3
            };

            //Act
            List<ArtItem> actual = repo.GetSelectedArtItems(allArtItems, theSelectedArtItems);

            //Assert
            Assert.Equal(expected, actual);
        }
        //    public async void UploadPictureToServer_ShouldReturnString()
        //    {
        //        //Arrange

        //        ArtItem artItem = new ArtItem()
        //        {
        //            Name = "Test",
        //            ArtistId = 1,
        //            Description = "hej mer test"
        //        };

        //        string imgPath = Path.Combine(Directory.GetCurrentDirectory(), "\\ARTiculate\\wwwroot\\UploadedImages\\GustavFalk2102020505502649.jpg");

        //        ArtItemViewModel imageModel = new ArtItemViewModel()
        //        {
        //            FileName = "TEST",
        //            ImageFile = (Microsoft.AspNetCore.Http.IFormFile)File.OpenRead(@imgPath),
        //            ArtItem = artItem
        //        };

        //        string expected = "~/UploadedImages/Test";


        //        //Act
        //        string actual = await repo.UploadPictureToServer(imageModel);
        //        string now = DateTime.Now.ToString("yyMMddhhmmssffff");

        //        //Assert
        //        Assert.Equal(actual, expected+now+"jpg");
        //    }

    }
}
