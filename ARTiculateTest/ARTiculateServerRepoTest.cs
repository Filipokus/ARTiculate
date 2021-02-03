using System;
using System.Collections.Generic;
using System.Text;
using ARTiculate.Data;
using Xunit;
using ARTiculate.Models;
using System.IO;

namespace ARTiculateTest
{
    public class ARTiculateServerRepoTest
    {
       ARTiulateServerRepository repo = new ARTiulateServerRepository("test");

        [Fact]
        public void UploadPictureToServer_ShouldReturnString()
        {
            //Arrange
            ImageModel imageModel = new ImageModel();
            imageModel.ImageName = "TEST";
            imageModel.Title = "TEST";
            imageModel.ImageFile = (Microsoft.AspNetCore.Http.IFormFile)File.OpenRead(@"ARTiculate1");

            //Act
            var actual = repo.UploadPictureToServer(imageModel);

            //Assert
        }

    }
}
