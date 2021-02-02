using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ARTiculate;
using ARTiculate.Data;
using ARTiculateDataAccessLibrary.Models;

namespace ARTiculateTest
{
    public class ARTiculateRepoTest
    {
        [Fact]
        public async void GetListOfTagsForSelectedVernisage_ShouldRetrunListOfTags()
        {
            //Arrange
            Vernisage vernisage = new Vernisage();
            List<Tag> expected = new List<Tag>();
           // ARTiculateRepository repo = new ARTiculateRepository();
            //Act
            List<Tag> actual = await ARTiculateRepository.GetListOfTagsForSelectedVernisage(vernisage); //Metoden måste vara static eller så måste man lägga till ytterligare tom konstruktor i ARTiculateRepository
            //Asset
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Sum_ShouldDoubleEntries()
        {
            //Arrange
            int expected = 12;
            //Act
            int actual = ARTiculateRepository.Sum();
            //Asset
            Assert.Equal(expected, actual);
        }

    }
}
