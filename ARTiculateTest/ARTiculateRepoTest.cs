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
        //this test class do not test methods directly in contact with the database
        ARTiculateRepositoryMock repo = new ARTiculateRepositoryMock("test");

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
    }
}
