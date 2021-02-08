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
        public async Task<Vernisage> AddVernisageAsync(Vernisage vernisage)
        {
            await db.Vernisages.AddAsync(vernisage);
            db.SaveChanges();

            return vernisage;            
        }

        /// <summary>
        /// Adds a vernisage to Db and returns the vernisageId from Db. Links the artist and vernisage together
        /// </summary>
        /// <param name="vernisage"></param>
        /// <param name="artistID"></param>
        /// <returns></returns>
        public async Task<int> AddVernisageAndReturnID(Vernisage vernisage, int artistID)
        {
            var vernisageFromDb = await AddVernisageAsync(vernisage);
            CreateArtist_Vernisage(vernisageFromDb.Id, artistID);

            return vernisageFromDb.Id;
        }

        /// <summary>
        /// Creates an object of type Artist_Vernisage
        /// </summary>
        /// <param name="vernisageId"></param>
        /// <param name="artistId"></param>
        public void CreateArtist_Vernisage(int vernisageId, int artistId)
        {
            Artist_Vernisage artist_Vernisage = new Artist_Vernisage
            {
                ArtistId = artistId,
                VernisageId = vernisageId
            };

            AddArtist_VernisageAsync(artist_Vernisage);

        }

        /// <summary>
        /// Adds an object of type Artist_Vernisage to Db
        /// </summary>
        /// <param name="artist_Vernisage"></param>
        public async void AddArtist_VernisageAsync(Artist_Vernisage artist_Vernisage)
        {
            await db.Artist_Vernisages.AddAsync(artist_Vernisage);
            db.SaveChanges();
        }

        /// <summary>
        /// Adds an object of type Exhibition to db 
        /// </summary>
        /// <param name="exhibition"></param>
        /// <returns></returns>
        public async Task<Exhibition> AddExhibitionAsync(Exhibition exhibition)
        {
            await db.Exhibitions.AddAsync(exhibition);
            await db.SaveChangesAsync();
            return exhibition;
        }

        /// <summary>
        /// Adds an object of type Artist to db 
        /// </summary>
        /// <param name="artist"></param>
        /// <returns></returns>
        public async Task<Artist> AddArtistAsync(Artist artist)
        {
            await db.Artists.AddAsync(artist);
            await db.SaveChangesAsync();
            return artist;
        }

        /// <summary>
        /// Method for creating new tag. Takes string with the name of the tag as input. Returns tag as object.
        /// </summary>
        /// <param name="tagname"></param>
        /// <returns></returns>
        public async Task<Tag> AddTagAsync(Tag tag)
        {
            await db.Tags.AddAsync(tag);
            await db.SaveChangesAsync();
            return tag;
        }

        public void GetMockData(ArtistContext db)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region READ

        //VERNISSAGE
        /// <summary>
        /// Method "Get" vernissage, input id and returns a vernissage. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Vernisage> GetVernisage(int id)
        {
            var vernisage = await db.Vernisages
              .Include(x => x.Artist_Vernisages).ThenInclude(y => y.Artist)
              .Include(x => x.Vernisage_Tags).ThenInclude(y => y.Tag)
              .Include(x => x.Exhibition)
              .Where(x => x.Id == id)
              .FirstOrDefaultAsync();

            return vernisage;
        }
        
        /// <summary>
        /// Returns a List containing all vernissages in db, sorted by date.
        /// </summary>
        /// <returns>List<Vernisage> vernissages ordered by date</Vernisage></returns>
        public async Task<List<Vernisage>> GetAllVernisagesOrderedByDate()
        {
            var vernissagesFromDb = await GetVernissagesFromDbOrderedByDate();
            var listOfVernissagesOrderedByDate = CreateListOfVernissages(vernissagesFromDb);

            return listOfVernissagesOrderedByDate;
        }

        /// <summary>
        /// Collects all vernissages from Db ordered by date and returns them
        /// </summary>
        /// <returns>vernissages from Db</returns>
        public async Task<List<Vernisage>> GetVernissagesFromDbOrderedByDate()
        {
            var vernissagesFromDb = await db.Vernisages
               .Include(x => x.Artist_Vernisages).ThenInclude(a => a.Artist)
               .Include(x => x.Vernisage_Tags).ThenInclude(y => y.Tag)
               .Include(x => x.Exhibition)
               .OrderBy(x => x.DateTime).ToListAsync();

            return vernissagesFromDb;
        }

        /// <summary>
        /// Loops through input and adds items to a list that will be returned
        /// </summary>
        /// <param name="vernissagesFromDb"></param>
        /// <returns>List<Vernisage> vernissages </returns>
        public List<Vernisage> CreateListOfVernissages(List<Vernisage> vernissagesFromDb)
        {
            List<Vernisage> vernissages = new List<Vernisage>();

            foreach (var vernissage in vernissagesFromDb)
            {
                vernissages.Add(vernissage);
            }

            return vernissages;
        }

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

        //EXHIBITIONS

        /// <summary>
        /// Returns a List containing all exhibitions in db, sorted by date.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Exhibition>> GetAllExhibitionsOrderedByDate()
        {
            var exhibitionsFromDb = await GetExhibitionsFromDbOrderedByDate();
            var listOfExhibitions = CreateListOfExhibitions(exhibitionsFromDb);

            return listOfExhibitions;
        }

        /// <summary>
        /// Collects all exhibitions from Db ordered by date and returns them
        /// </summary>
        /// <returns>List<Exhibition> exhibitionsFromDb </returns>        
        public async Task<List<Exhibition>> GetExhibitionsFromDbOrderedByDate()
        {
            var exhibitionsFromDb = await db.Exhibitions
              .Include(x => x.Artist_Exhibitions)
              .Include(x => x.Exhibition_Tags).ThenInclude(y => y.Tag)
              .OrderBy(x => x.DateTime).ToListAsync();

            return exhibitionsFromDb;
        }

        /// <summary>
        /// Loops through input and adds items to a list that will be returned
        /// </summary>
        /// <param name="exhibitionsFromDb"></param>
        /// <returns>List<Exhibition> exhibitions </returns>
        public List<Exhibition> CreateListOfExhibitions(List<Exhibition> exhibitionsFromDb)
        {
            List<Exhibition> exhibitions = new List<Exhibition>();

            foreach (var exhibition in exhibitionsFromDb)
            {
                exhibitions.Add(exhibition);
            }

            return exhibitions;
        }

        /// <summary>
        /// Method "Get" exhibition, input id and returns a exhibition.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Exhibition> GetExhibition(int id)
        {
            var exhibition = await db.Exhibitions
              .Include(x => x.Artist_Exhibitions).ThenInclude(y => y.Artist)
              .Include(x => x.Exhibition_Tags).ThenInclude(y => y.Tag)
              .Where(x => x.Id == id)
              .FirstOrDefaultAsync();

            return exhibition;
        }

        /// <summary>
        /// Returns a list with name and id of all the tags that the slected exhibition holds
        /// </summary>
        /// <param name="exhibition"></param>
        /// <returns></returns>
        public List<Tag> GetListOfTagsForSelectedExhibition(Exhibition exhibition)
        {
            List<Tag> tags = new List<Tag>();

            foreach (var item in exhibition.Exhibition_Tags)
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

        #endregion

        #region UPDATE

        #endregion

        #region DELETE

        #endregion

          
      
    }
}
