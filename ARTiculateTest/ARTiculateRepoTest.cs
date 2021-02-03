using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ARTiculate;
using ARTiculate.Data;
using ARTiculateDataAccessLibrary.Models;
using ARTiculateDataAccessLibrary.DataAccess;

namespace ARTiculateTest
{
    public class ARTiculateRepoTest
    {
        ARTiculateRepository repo = new ARTiculateRepository("test");

        [Fact]
        public void GetListOfTagsForSelectedVernisage_ShouldRetrunListOfTags()
        {
            //Arrange

            Tag tag = new Tag
            {
                TagName = "Rymden"
            };

            Vernisage_Tag vernisage_Tag = new Vernisage_Tag();

            vernisage_Tag.Tag = tag;

            List<Vernisage_Tag> vernisage_Tags = new List<Vernisage_Tag>();

            vernisage_Tags.Add(vernisage_Tag);

            Vernisage vernisage = new Vernisage();

            vernisage.Vernisage_Tags = vernisage_Tags;

            List<Tag> expected = new List<Tag>();
            expected.Add(tag);

            //Act
            List<Tag> actual = repo.GetListOfTagsForSelectedVernisage(vernisage);
            
            //Asset
            Assert.True(actual.Count > 0);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void GetArtist_ShouldReturnOneArtist()
        {
            //Arrange
            int artistId = 1;
            Artist expected = new Artist();
            //Act
            Artist actual = await repo.GetArtist(artistId);
            //Asset
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void GetAllVernisagesOrderedByDate_ShouldReturnAllVernisagesOrderedByDate()
        {
            //Arrange
            List<Vernisage> vernisages = new List<Vernisage>();

            //Act
            List<Vernisage> actual = await repo.GetAllVernisagesOrderedByDate();

        }

        [Fact]
        public async void GetVernisage_ShouldReturnOneVernisage()
        {
            //Arrange
            int vernisageId = 1;
            Vernisage expected = new Vernisage();
            //Act
            Vernisage actual = await repo.GetVernisage(vernisageId);
            //Asset
            Assert.Equal(expected, actual);
        }
    }
}
