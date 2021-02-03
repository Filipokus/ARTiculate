using ARTiculateDataAccessLibrary.DataAccess;
using ARTiculateDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ARTiculate.Data
{
    public class ARTiculateRepository : IARTiculateRepository
    {
        ArtistContext db;

        #region CONSTRUCT
        public ARTiculateRepository(ArtistContext context)
        {
            db = context;
        }
        /// <summary>
        /// Ctor for test class to avoid an empty ctor
        /// </summary>
        /// <param name="test"></param>
        public ARTiculateRepository(string test) { }

        #endregion

        #region CREATE
        /// <summary>
        /// Adds a object of type Vernisage to db
        /// </summary>
        /// <param name="vernisage"></param>
        /// <returns></returns>
        public async Task AddVernisageAsync(Vernisage vernisage)
        {
            await db.Vernisages.AddAsync(vernisage);
            db.SaveChanges();
        }

        /// <summary>
        /// Method for create artist, input firstname and lastname. Returns an artist. 
        /// </summary>
        /// <param name="fristname"></param>
        /// <param name="lastname"></param>
        /// <returns></returns>
        public async Task<Artist> CreateArtist(string fristname, string lastname)
        {
            var artist = new Artist
            {
                Firstname = fristname,
                Lastname = lastname,
                //TODO Behöver lite mer properties för att skapa ett Artist-objekt?
            };
            await db.AddAsync(artist);
            db.SaveChanges();
            return artist;
        }
        /// <summary>
        /// Method for creating new tag. Takes string with the name of the tag as input. Returns tag as object.
        /// </summary>
        /// <param name="tagname"></param>
        /// <returns></returns>
        public async Task<Tag> CreateTag(string tagname)
        {
            var tag = new Tag
            {
                TagName = tagname,
            };
            await db.AddAsync(tag);
            db.SaveChanges();
            return tag;
        }

        public void GetMockData(ArtistContext db)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region READ
        /// <summary>
        /// Returns a list with name and id of all the tags that the slected vernisage holds
        /// </summary>
        /// <param name="vernisage"></param>
        /// <returns></returns>
        public List<Tag> GetListOfTagsForSelectedVernisage(Vernisage vernisage)
        {
            List<Tag> tags = new List<Tag>();

            foreach (var item in vernisage.Vernisage_Tags)
            {
                tags.Add(item.Tag);
            }

            return tags;
        }

        /// <summary>
        /// Returns an artist from the db by taking the id (int) as input.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Artist> GetArtist(int id)
        {
            var artist = await db.Artists
               .Include(x => x.ArtItems).ThenInclude(y => y.ArtItem_Tags)
               .Include(x => x.Artist_Vernisages)
               .Include(x => x.Artist_Exhibitions)
               .Include(x => x.Artist_Tags)
               .Where(x => x.Id == id)
               .FirstOrDefaultAsync();

                return artist;
        }

        /// <summary>
        /// Returns a List containing all vernissages in db, sorted by date.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Vernisage>> GetAllVernisagesOrderedByDate()
        {
            var vernisagesDetails = await db.Vernisages
                .Include(x => x.Artist_Vernisages)
                .Include(x => x.Vernisage_Tags).ThenInclude(y => y.Tag)
                .OrderBy(x => x.DateTime).ToListAsync();

            List<Vernisage> vernisages = new List<Vernisage>();

            foreach (var vernisage in vernisagesDetails)
            {
                vernisages.Add(vernisage);
            }

            return vernisages;
        }

        /// <summary>
        /// Method "Get" vernissage, input id and returns a vernissage. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Vernisage> GetVernisage(int id)
        {
            var vernisage = await db.Vernisages
              .Include(x => x.Artist_Vernisages)
              .Include(x => x.Vernisage_Tags).ThenInclude(y => y.Tag)
              .Where(x => x.Id == id)
              .FirstOrDefaultAsync();

            return vernisage;
        }
        #endregion

        #region UPDATE

        #endregion

        #region DELETE

        #endregion

          
      
    }
}
