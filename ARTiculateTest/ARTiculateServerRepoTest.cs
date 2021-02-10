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

        [Fact]
        public async void UploadPictureToServer_ShouldReturnString()
        {
            //Arrange

            ArtItem artItem = new ArtItem()
            {
                Name = "Test",
                ArtistId = 1,
                Description = "hej mer test"
            };

            string imgPath = Path.Combine(Directory.GetCurrentDirectory(), "\\ARTiculate\\wwwroot\\UploadedImages\\GustavFalk2102020505502649.jpg");

            ArtItemViewModel imageModel = new ArtItemViewModel()
            {
                FileName = "TEST",
                ImageFile = (Microsoft.AspNetCore.Http.IFormFile)File.OpenRead(@imgPath),
                ArtItem = artItem
            };

            string expected = "~/UploadedImages/Test";


            //Act
          //  string actual = await repo.UploadPictureToServer(imageModel);
            string now = DateTime.Now.ToString("yyMMddhhmmssffff");

            //Assert
            //Assert.Equal(actual, expected+now+"jpg");
        }

    }
}
