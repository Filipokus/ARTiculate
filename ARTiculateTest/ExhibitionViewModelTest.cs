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
        public void SortExhibitionsByTagName_ShouldReturnExhibitionsByTag()
        {
            //Arrange
            string tagName = "rymden";

            Tag tagRymden = new Tag
            {
                TagName = "rymden"
            };

            Tag tagSpace = new Tag
            {
                TagName = "space"
            };

            Tag tagSkog = new Tag
            {
                TagName = "skog"
            };

            Tag tagPaint = new Tag
            {
                TagName = "paint"
            };

            Exhibition_Tag exhibition_tagRymden = new Exhibition_Tag();
            Exhibition_Tag exhibition_tagSpace = new Exhibition_Tag();
            Exhibition_Tag exhibition_tagSkog = new Exhibition_Tag();
            Exhibition_Tag exhibition_tagPaint = new Exhibition_Tag();

            exhibition_tagRymden.Tag = tagRymden;
            exhibition_tagSpace.Tag = tagSpace;
            exhibition_tagSkog.Tag = tagSkog;
            exhibition_tagPaint.Tag = tagPaint;

            Exhibition exhibitionRymdenSpace = new Exhibition
            { 
                Title = "Rymden And Space"
            };

            Exhibition exhibitionSkogPaint = new Exhibition
            {
                Title = "Skog And Paint"
            };

            Exhibition exhibitionAllTags = new Exhibition
            {
                Title = "All Test Tags"
            };

            //Rymden and Space
            exhibitionRymdenSpace.Exhibition_Tags.Add(exhibition_tagRymden);
            exhibitionRymdenSpace.Exhibition_Tags.Add(exhibition_tagSpace);

            //Skog and paint
            exhibitionSkogPaint.Exhibition_Tags.Add(exhibition_tagSkog);
            exhibitionSkogPaint.Exhibition_Tags.Add(exhibition_tagPaint);

            //All test tags
            exhibitionAllTags.Exhibition_Tags.Add(exhibition_tagRymden);
            exhibitionAllTags.Exhibition_Tags.Add(exhibition_tagSpace);
            exhibitionAllTags.Exhibition_Tags.Add(exhibition_tagSkog);
            exhibitionAllTags.Exhibition_Tags.Add(exhibition_tagPaint);

            //Adds all exhibitions above in list och exhibitions
            List<Exhibition> listofAllTestExhibitions = new List<Exhibition>();
            listofAllTestExhibitions.Add(exhibitionRymdenSpace);
            listofAllTestExhibitions.Add(exhibitionSkogPaint);
            listofAllTestExhibitions.Add(exhibitionAllTags);

            //The result should only contain exhibitionRymdenSpace and exhibitionAllTags
            List<Exhibition> expected = new List<Exhibition>();
            expected.Add(exhibitionRymdenSpace);
            expected.Add(exhibitionAllTags);

            //Act
            var actual = viewModel.SortExhibitionsByTagName(tagName, listofAllTestExhibitions);

            //Assert
            Assert.Equal(expected, actual);
        }

        //[Fact]
        //public void GetArtistsForSelectedExhibition_ShouldRetrunListOfArtists()
        //{
        //    //Arrange
        //    Artist artist = new Artist
        //    {
        //        Id = 1,
        //        Firstname = "Test",
        //        Lastname = "Testsson"
        //    };

        //    Artist artistTwo = new Artist
        //    {
        //        Id = 2,
        //        Firstname = "Jest",
        //        Lastname = "Jestsson"
        //    };

        //    Artist_Exhibition artist_Exhibition = new Artist_Exhibition
        //    {
        //        Artist = artist
        //    };

        //    Artist_Exhibition artist_ExhibitionTwo = new Artist_Exhibition
        //    {
        //        Artist = artistTwo
        //    };

        //    List<Artist_Exhibition> artist_Exhibitions = new List<Artist_Exhibition>();
        //    artist_Exhibitions.Add(artist_Exhibition);
        //    artist_Exhibitions.Add(artist_ExhibitionTwo);

        //    Exhibition exhibition = new Exhibition
        //    {
        //        Artist_Exhibitions = artist_Exhibitions
        //    };

        //    List<Artist> expected = new List<Artist>();
        //    expected.Add(artist);
        //    expected.Add(artistTwo);

        //    //Act
        //    List<Artist> actual = viewModel.GetArtistsForSelectedExhibition(exhibition);

        //    //Assert
        //    Assert.True(actual != null);
        //    Assert.Equal(expected, actual);

        //}
    }
}
