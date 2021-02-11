using ARTiculateDataAccessLibrary.DataAccess;
using ARTiculate.Areas.Identity.Data;
using ARTiculateDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace ARTiculate.Data
{
    public class ARTiculateRepositoryMock : IARTiculateRepository
    {
        ArtistContext db;

        #region CONSTRUCT
        public ARTiculateRepositoryMock(ArtistContext context)
        {
            db = context;
        }
        /// <summary>
        /// Ctor for test class to avoid an empty ctor
        /// </summary>
        /// <param name="test"></param>
        public ARTiculateRepositoryMock(string test) { }

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
        /// Adds an object of type Artist_Exhibition to Db
        /// </summary>
        /// <param name="artist_Vernisage"></param>
        public async void AddArtist_ExhibitionAsync(Artist_Exhibition artist_Exhibition)
        {
            await db.Artist_Exhibitions.AddAsync(artist_Exhibition);
            db.SaveChanges();
        }

        /// <summary>
        /// Creates an object of type Artist_Exhibition
        /// </summary>
        /// <param name="vernisageId"></param>
        /// <param name="artistId"></param>
        public void CreateArtist_Exhibition(int exhibitionId, int artistId)
        {
            Artist_Exhibition artist_Exhibition = new Artist_Exhibition
            {
                ArtistId = artistId,
                ExhibitionId = exhibitionId
            };

            AddArtist_ExhibitionAsync(artist_Exhibition);

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

        public Artist CreateArtistFromARTiculateUser(ARTiculateUser user)
        {
            Artist artist = new Artist()
            {
                Emailadress = user.Email,
                Firstname = user.FirstName,
                Lastname = user.LastName,

            };
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

        public async Task<ArtItem> AddArtItem(ArtItem artItem)
        {
            await db.ArtItems.AddAsync(artItem);
            await db.SaveChangesAsync();
            return artItem;
        }

        public void GetMockData(ArtistContext db)
        {
            //var fileArtist = File.ReadAllText("Mock/Artist.json");
            //var resultArtist = JsonConvert.DeserializeObject<IEnumerable<Artist>>(fileArtist);
            //db.AddRange(resultArtist);
            //db.SaveChanges();

            //var fileArtItem = File.ReadAllText("Mock/ArtItem.json");
            //var resultArtItem = JsonConvert.DeserializeObject<IEnumerable<ArtItem>>(fileArtItem);
            //db.AddRange(resultArtItem);
            //db.SaveChanges();

            //var fileExhibition = File.ReadAllText("Mock/Exhibition.json");
            //var resultExhibition = JsonConvert.DeserializeObject<IEnumerable<Exhibition>>(fileExhibition);
            //db.AddRange(resultExhibition);
            //db.SaveChanges();

            //var fileExhibition_ArtItems = File.ReadAllText("Mock/Exhibition_ArtItems.json");
            //var resultExhibition_ArtItems = JsonConvert.DeserializeObject<IEnumerable<Exhibition_ArtItem>>(fileExhibition_ArtItems);
            //db.AddRange(resultExhibition_ArtItems);
            //db.SaveChanges();

            //var fileLink = File.ReadAllText("Mock/Link.json");
            //var resultLink = JsonConvert.DeserializeObject<IEnumerable<Link>>(fileLink);
            //db.AddRange(resultLink);
            //db.SaveChanges();

            //var fileTag = File.ReadAllText("Mock/Tag.json");
            //var resultTag = JsonConvert.DeserializeObject<IEnumerable<Tag>>(fileTag);
            //db.AddRange(resultTag);
            //db.SaveChanges();

            //var fileVernisage = File.ReadAllText("Mock/Vernisage.json");
            //var resultVernisage = JsonConvert.DeserializeObject<IEnumerable<Vernisage>>(fileVernisage);
            //db.AddRange(resultVernisage);
            //db.SaveChanges();

            //var fileArtItem_Tag = File.ReadAllText("Mock/ArtItem_Tag.json");
            //var resultArtItem_Tag = JsonConvert.DeserializeObject<IEnumerable<ArtItem_Tag>>(fileArtItem_Tag);
            //db.AddRange(resultArtItem_Tag);
            //db.SaveChanges();

            //var fileArtist_Exhibition = File.ReadAllText("Mock/Artist_Exhibition.json");
            //var resultArtist_Exhibition = JsonConvert.DeserializeObject<IEnumerable<Artist_Exhibition>>(fileArtist_Exhibition);
            //db.AddRange(resultArtist_Exhibition);
            //db.SaveChanges();

            //var fileArtist_Tag = File.ReadAllText("Mock/Artist_Tag.json");
            //var resultArtist_Tag = JsonConvert.DeserializeObject<IEnumerable<Artist_Tag>>(fileArtist_Tag);
            //db.AddRange(resultArtist_Tag);
            //db.SaveChanges();

            //var fileExhibition_Tag = File.ReadAllText("Mock/Exhibition_Tag.json");
            //var resultExhibition_Tag = JsonConvert.DeserializeObject<IEnumerable<Exhibition_Tag>>(fileExhibition_Tag);
            //db.AddRange(resultExhibition_Tag);
            //db.SaveChanges();

            //var fileArtist_Vernisage = File.ReadAllText("Mock/Artist_Vernisage.json");
            //var resultArtist_Vernisage = JsonConvert.DeserializeObject<IEnumerable<Artist_Vernisage>>(fileArtist_Vernisage);
            //db.AddRange(resultArtist_Vernisage);
            //db.SaveChanges();

            //var fileVernisage_Tag = File.ReadAllText("Mock/Vernisage_Tag.json");
            //var resultVernisage_Tag = JsonConvert.DeserializeObject<IEnumerable<Vernisage_Tag>>(fileVernisage_Tag);
            //db.AddRange(resultVernisage_Tag);
            //db.SaveChanges();
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
        /// Returns a List containing all vernissages that is still to come
        /// </summary>
        /// <returns></returns>
        public async Task<List<Vernisage>> GetAllVernisagesToCome()
        {
            List<Vernisage> allVernisages = await GetAllVernisagesOrderedByDate();
            List<Vernisage> commingVernisages = new List<Vernisage>();

            
                var rightNow = DateTime.Now;
            foreach (var vernisage in allVernisages)
            {
               
                if (rightNow < vernisage.DateTime)
                {
                    commingVernisages.Add(vernisage);
                }
            }

            return commingVernisages;
        }


        
        /// <summary>
        /// Returns a List containing all live vernisages
        /// </summary>
        /// <returns></returns>
        public async Task<List<Vernisage>> GetLiveVernisages()
        {
            List<Vernisage> allVernisages = await GetAllVernisagesOrderedByDate();
            List<Vernisage> liveVernisages = new List<Vernisage>();

            var rightNow = DateTime.Now;

            foreach (var vernisage in allVernisages)
            {
                if (rightNow >= vernisage.DateTime && rightNow <= vernisage.DateTime.AddHours(vernisage.Duration) )
                {
                    liveVernisages.Add(vernisage);
                }
            }

            return liveVernisages;
        }


        /// <summary>
        /// Returns a List containing all active vernisages
        /// </summary>
        /// <returns></returns>
        public async Task<List<Vernisage>> GetActiveVernisages()
        {
            var vernisagesDetails = await db.Vernisages
               .Include(x => x.Artist_Vernisages).ThenInclude(a => a.Artist)
               .Where(v => v.Open == true)
               .OrderBy(x => x.DateTime).ToListAsync();

            List<Vernisage> activeVernisages = new List<Vernisage>();

            foreach (var vernisage in vernisagesDetails)
            {
                activeVernisages.Add(vernisage);
            }

            return activeVernisages;
        }


        //TODO Ta bort den här metoden??
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
              .Include(x => x.Exhibition_ArtItem).ThenInclude(x => x.ArtItems)
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


        //TODO ta bort den här metoden??
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

        /// <summary>
        /// Returns an artist that is referenced in the ARTiculateUser
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Artist> GetArtistFromARTiculateUser(ARTiculateUser user)
        {
            var artist = await db.Artists
               .Include(x => x.ArtItems).ThenInclude(y => y.ArtItem_Tags)
               .Include(x => x.Artist_Vernisages)
               .Include(x => x.Artist_Exhibitions)
               .Include(x => x.Artist_Tags)
               .Where(x => x.Emailadress == user.Email)
               .FirstOrDefaultAsync();

            return artist;
        }


        public async Task<ArtItem> GetArtItem(int id)
        {
            var artItem = await db.ArtItems
                .Include(x => x.Artist)
                .Include(x => x.ArtItem_Tags)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return artItem;
        }

        public async Task<List<Exhibition>> GetAllExhibitionsFromArtistAsync(int id)
        {
            List<Artist_Exhibition> exhibitionsRaw = await db.Artist_Exhibitions
                .Include(x => x.Artist)
                .Include(x => x.Exhibition)
                .Where(x => x.ArtistId == id)
                .ToListAsync();

            List<Exhibition> exhibitions = new List<Exhibition>();

            foreach (Artist_Exhibition exhibition in exhibitionsRaw)
            {
                exhibitions.Add(exhibition.Exhibition);
            }

            return exhibitions;
        }

        //TODO förenkla metoden. Eventuellt ändra i databasen för att begränsa så att en exhibition enbart kan hållas av EN artist

        public async Task<List<Exhibition>> GetAllExhibitionsWithOutVernissageFromArtist(int id)
        {
            List<Exhibition> allExhibitions = await GetAllExhibitionsFromArtistAsync(id);
            List<Vernisage> vernissages = await GetVernissagesFromDbOrderedByDate();
            List<Exhibition> exhibitionsthatsNotAvailableToCreateVernissage = new List<Exhibition>();

            foreach (Exhibition exhibition in allExhibitions)
            {
                foreach (Vernisage vernissage in vernissages)
                {
                    if (exhibitionsthatsNotAvailableToCreateVernissage.Contains(exhibition))
                    {
                        break;
                    }
                    else if (exhibition.Id == vernissage.ExhibitionId)
                    {
                        exhibitionsthatsNotAvailableToCreateVernissage.Add(exhibition);
                    }
                }
            }

            foreach (Exhibition exhibit in exhibitionsthatsNotAvailableToCreateVernissage)
            {
                allExhibitions.Remove(exhibit);
            }

            return allExhibitions;
        }


        #endregion

        #region UPDATE

        public async Task<ArtItem> UpdateArtItem(ArtItem artItem)
        {
            db.ArtItems.Update(artItem);
            await db.SaveChangesAsync();
            return artItem;
        }

        public async Task<Exhibition> UpdateExhibition(Exhibition exhibition)
        {
            db.Exhibitions.Update(exhibition);
            await db.SaveChangesAsync();
            return exhibition;
        }

        public async Task<Vernisage> UpdateVernissage(Vernisage vernissage)
        {
            db.Vernisages.Update(vernissage);
            await db.SaveChangesAsync();
            return vernissage;
        }

        #endregion

        #region DELETE

        #endregion



    }
}
