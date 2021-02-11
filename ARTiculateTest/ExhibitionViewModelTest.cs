using ARTiculate.Data;
using ARTiculate.Models;
using ARTiculateDataAccessLibrary.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ARTiculateTest
{
    public class ExhibitionViewModelTest
    {
        ExhibitionViewModel viewModel = new ExhibitionViewModel();

        private readonly List<Exhibition> listofAllTestExhibitions;

        public ExhibitionViewModelTest()
        {
            listofAllTestExhibitions = MockTestData();
        }

        private List<Exhibition> MockTestData()
        {
            //Arrange
            string tagName = "rymden";

            Tag tagRymden = new Tag { TagName = "rymden" };
            Tag tagSpace = new Tag { TagName = "space" };
            Tag tagSkog = new Tag { TagName = "skog" };
            Tag tagPaint = new Tag { TagName = "paint" };

            ArtItem artItemBowl = new ArtItem { Name = "Mystic" };
            ArtItem artItemTree = new ArtItem { Name = "Tree" };
            ArtItem artItemStone = new ArtItem { Name = "Stone" };
            ArtItem artItemFace = new ArtItem { Name = "Face" };

            Exhibition_ArtItem exhibition_ArtItemBowl = new Exhibition_ArtItem { ArtItems = artItemBowl };
            Exhibition_ArtItem exhibition_ArtItemTree = new Exhibition_ArtItem { ArtItems = artItemTree };
            Exhibition_ArtItem exhibition_ArtItemStone = new Exhibition_ArtItem { ArtItems = artItemStone };
            Exhibition_ArtItem exhibition_ArtItemFace = new Exhibition_ArtItem { ArtItems = artItemFace };

            Exhibition_Tag exhibition_tagRymden = new Exhibition_Tag();
            Exhibition_Tag exhibition_tagSpace = new Exhibition_Tag();
            Exhibition_Tag exhibition_tagSkog = new Exhibition_Tag();
            Exhibition_Tag exhibition_tagPaint = new Exhibition_Tag();

            exhibition_tagRymden.Tag = tagRymden;
            exhibition_tagSpace.Tag = tagSpace;
            exhibition_tagSkog.Tag = tagSkog;
            exhibition_tagPaint.Tag = tagPaint;

            Exhibition exhibitionRymdenSpace = new Exhibition { Title = "Rymden And Space" };
            Exhibition exhibitionSkogPaint = new Exhibition { Title = "Skog And Paint" };
            Exhibition exhibitionAllTags = new Exhibition { Title = "All Test Tags" };

            //Rymden and Space
            exhibitionRymdenSpace.Exhibition_Tags.Add(exhibition_tagRymden);
            exhibitionRymdenSpace.Exhibition_Tags.Add(exhibition_tagSpace);

            exhibitionRymdenSpace.Exhibition_ArtItem.Add(exhibition_ArtItemBowl);
            exhibitionRymdenSpace.Exhibition_ArtItem.Add(exhibition_ArtItemTree);
            exhibitionRymdenSpace.Exhibition_ArtItem.Add(exhibition_ArtItemStone);
            exhibitionRymdenSpace.Exhibition_ArtItem.Add(exhibition_ArtItemFace);

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

            return listofAllTestExhibitions;
        }

        [Theory]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void GetNewlyAddedExhibitionsForView_ShouldReturnList(int numberOfExhibitions)
        {
            // Arrange
            var expected = 6;

            List<Exhibition> exhibitions = new List<Exhibition>();

            for (int i = 0; i < numberOfExhibitions; i++)
            {
                Exhibition exhibiton = new Exhibition { Title = $"test{i}" };
                List<Exhibition_ArtItem> exhibition_ArtItems = new List<Exhibition_ArtItem>();
                exhibiton.Exhibition_ArtItem = exhibition_ArtItems;

                for (int j = 0; j < 4; j++)
                {
                    Exhibition_ArtItem artItem = new Exhibition_ArtItem { ArtItemId = j };
                    exhibition_ArtItems.Add(artItem);
                }
                exhibitions.Add(exhibiton);
            }

            // Act
            var actual = viewModel.GetNewlyAddedExhibitionsForView(exhibitions);

            // Assert
            Assert.Equal(expected, actual.Count);
        }

        [Fact]
        public void CreatesNewListWithFourPictures_ShouldReturnExhibitionsWithOnlyFourPosters()
        {
            //Arrange
            List<Exhibition> test = MockTestData();

            //List<Exhibition> expected = new List<Exhibition>();
            //expected.Add(listofAllTestExhibitions[0]);

            ArtItem artItemStoneFace = new ArtItem { Name = "StoneFace" };
            Exhibition_ArtItem exhibition_ArtItemStoneFace = new Exhibition_ArtItem { ArtItems = artItemStoneFace };

            test[0].Exhibition_ArtItem.Add(exhibition_ArtItemStoneFace);

            //Act
            List<Exhibition> actual = viewModel.CreateNewListWithFourPictures(test);

            //Assert
            Assert.True(actual[0].Exhibition_ArtItem.Count == 4);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void AddMaxSixExhibtionsToList_ShouldReturnSixExhibitions(int nuberOfExhibitions)
        {
            // Arrange
            int expected = 6;

            List<Exhibition> exhibitions = new List<Exhibition>();

            for (int i = 0; i < nuberOfExhibitions; i++)
            {
                var newExhibition = new Exhibition { Title = $"test{i}" };
                exhibitions.Add(newExhibition);
            }

            // Act
            var actual = viewModel.AddMaxSixExhibtionsToList(exhibitions);

            // Assert
            Assert.True(actual.Count == expected);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void CheckIfExhibitionContainsFourPosters_ShouldWork(int numberOfArtitems)
        {
            // Arrange
            bool expected;

            if (numberOfArtitems == 4)
            {
                expected = true;
            }
            else
            {
                expected = false;
            }

            List<Exhibition> exhibitions = new List<Exhibition> { new Exhibition { Title="test" } };
            List<Exhibition_ArtItem> exhibition_ArtItems = new List<Exhibition_ArtItem>();
            exhibitions[0].Exhibition_ArtItem = exhibition_ArtItems;

            for (int i = 0; i < numberOfArtitems; i++)
            {
                Exhibition_ArtItem artItem = new Exhibition_ArtItem { ArtItemId = i};
                exhibition_ArtItems.Add(artItem);
            }

            bool actual = viewModel.CheckIfExhibitionContainsFourPosters(exhibitions);

            Assert.Equal(expected, actual);
        }
            
        [Fact]
        public void SortExhibitionsByTagName_ShouldReturnExhibitionsByTag()
        {
            //Arrange
            string tagName = "rymden";

            Tag tagRymden = new Tag { TagName = "rymden" };
            Tag tagSpace = new Tag { TagName = "space" };
            Tag tagSkog = new Tag { TagName = "skog" };
            Tag tagPaint = new Tag { TagName = "paint" };

            Exhibition_Tag exhibition_tagRymden = new Exhibition_Tag();
            Exhibition_Tag exhibition_tagSpace = new Exhibition_Tag();
            Exhibition_Tag exhibition_tagSkog = new Exhibition_Tag();
            Exhibition_Tag exhibition_tagPaint = new Exhibition_Tag();

            exhibition_tagRymden.Tag = tagRymden;
            exhibition_tagSpace.Tag = tagSpace;
            exhibition_tagSkog.Tag = tagSkog;
            exhibition_tagPaint.Tag = tagPaint;

            Exhibition exhibitionRymdenSpace = new Exhibition { Title = "Rymden And Space" };
            Exhibition exhibitionSkogPaint = new Exhibition { Title = "Skog And Paint" };
            Exhibition exhibitionAllTags = new Exhibition { Title = "All Test Tags" };

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
            Assert.True(actual.Count >= 1);
            Assert.Contains<Exhibition>(exhibitionAllTags, expected);
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
