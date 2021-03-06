﻿using ARTiculate.Areas.Identity.Data;
using ARTiculateDataAccessLibrary.DataAccess;
using ARTiculateDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        #region Vernissage

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

        #endregion

        #region Exhibition

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
        public async Task AddArtist_ExhibitionAsync(Artist_Exhibition artist_Exhibition)
        {
            await db.Artist_Exhibitions.AddAsync(artist_Exhibition);
            db.SaveChanges();
        }

        /// <summary>
        /// Creates an object of type Artist_Exhibition
        /// </summary>
        /// <param name="vernisageId"></param>
        /// <param name="artistId"></param>
        public async Task CreateArtist_Exhibition(int exhibitionId, int artistId)
        {
            Artist_Exhibition artist_Exhibition = new Artist_Exhibition
            {
                ArtistId = artistId,
                ExhibitionId = exhibitionId
            };

            await AddArtist_ExhibitionAsync(artist_Exhibition);

        }

        /// <summary>
        /// Creates an Exhibition_ArtItem foreach List<ArtItem> object
        /// </summary>
        /// <param name="artItems"></param>
        /// <param name="exhibitionId"></param>
        /// <returns></returns>
        public async Task CreateExhibition_ArtItemsAsync(List<ArtItem> artItems, int exhibitionId)
        {
            foreach (ArtItem artItem in artItems)
            {

                Exhibition_ArtItem exhibition_ArtItem = new Exhibition_ArtItem
                {
                    ArtItemId = artItem.Id,
                    ExhibitionId = exhibitionId
                };

                await AddArtItemToExhibition(exhibition_ArtItem);
            }
        }

        #endregion

        #region ArtItem

        /// <summary>
        /// Adds an ArtItem into db
        /// </summary>
        /// <param name="artItem"></param>
        /// <returns> ArtItem </returns>
        public async Task<ArtItem> AddArtItem(ArtItem artItem)
        {
            await db.ArtItems.AddAsync(artItem);
            await db.SaveChangesAsync();
            return artItem;
        }

        /// <summary>
        /// Adds an "ArtItem" to an "Exhibition"
        /// </summary>
        /// <param name="exhibition_ArtItem"></param>
        /// <returns></returns>
        public async Task<Exhibition_ArtItem> AddArtItemToExhibition(Exhibition_ArtItem exhibition_ArtItem)
        {

            await db.Exhibition_ArtItems.AddAsync(exhibition_ArtItem);
            db.SaveChanges();


            return exhibition_ArtItem;
        }

        #endregion

        #region Artist

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
        /// Creates an Artist from an ARTiculateUser
        /// </summary>
        /// <param name="user"></param>
        /// <returns> Artist </returns>
        public Artist CreateArtistFromARTiculateUser(ARTiculateUser user)
        {
            Artist artist = new Artist()
            {
                Emailadress = user.Email,
                Firstname = user.FirstName,
                Lastname = user.LastName,
                ProfilePicture = "~/UploadedImages/profilepicture.png"

            };
            return artist;
        }

        #endregion

        #region Tags

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

        /// <summary>
        /// Adds an object of type <ArtItem_Tag> into Db
        /// </summary>
        /// <param name="artItem_Tag"></param>
        /// <returns name="artItem_Tag"></returns>
        public async Task<ArtItem_Tag> AddArtItemTag(ArtItem_Tag artItem_Tag)
        {
            await db.ArtItem_Tags.AddAsync(artItem_Tag);
            await db.SaveChangesAsync();
            return artItem_Tag;
        }

        /// <summary>
        /// Takes a string with tags (#tag1, #tag2) and returns List<Tag> with added Tags in Db
        /// </summary>
        /// <param name="tagsRaw"></param>
        /// <returns name="addedTags"></returns>
        public async Task<List<Tag>> AddTagsAsync(string tagsRaw)
        {
            string[] tags = tagsRaw.Split(' ');
            List<Tag> addedTags = new List<Tag>();

            foreach (string tagRaw in tags)
            {
                string tagString = tagRaw.Substring(1);
                Tag addedTag = GetTagByName(tagString);

                if (addedTag.Id != 0)
                {
                    addedTags.Add(addedTag);
                }

                else
                {
                    Tag tag = new Tag
                    {
                        TagName = tagString
                    };

                    addedTag = await AddTagAsync(tag);
                    addedTags.Add(addedTag);
                }
            }

            return addedTags;
        }

        /// <summary>
        /// Takes a string of tags (#tag1, #tag2) and an ArtItem id to create ArtItem_Tags into Db
        /// </summary>
        /// <param name="tagsRaw"></param>
        /// <param name="id"></param>
        /// <returns name="artItem_Tags"></returns>
        public async Task<List<ArtItem_Tag>> AddArtItem_Tags(string tagsRaw, int id)
        {
            List<Tag> tags = await AddTagsAsync(tagsRaw);

            List<ArtItem_Tag> artItem_Tags = new List<ArtItem_Tag>();

            foreach (Tag tag in tags)
            {
                ArtItem_Tag artItem_Tag = new ArtItem_Tag
                {
                    TagId = tag.Id,
                    ArtItemId = id
                };
                ArtItem_Tag addedArtItem_Tag = await AddArtItemTag(artItem_Tag);
                artItem_Tags.Add(addedArtItem_Tag);
            }

            return artItem_Tags;
        }

        #endregion

        #region Mockdata
        /// <summary>
        /// Reads files with mockdata and saves it do Db.
        /// </summary>
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

        #endregion

        #region READ

        #region Vernissage

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
               .OrderByDescending(x => x.DateTime).ToListAsync();

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
                if (rightNow >= vernisage.DateTime && rightNow <= vernisage.DateTime.AddHours(vernisage.Duration))
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
               .OrderByDescending(x => x.DateTime).ToListAsync();

            List<Vernisage> activeVernisages = new List<Vernisage>();

            foreach (var vernisage in vernisagesDetails)
            {
                activeVernisages.Add(vernisage);
            }
            return activeVernisages;
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
        #endregion

        #region Exhibition
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
              .OrderByDescending(x => x.DateTime).ToListAsync();

            return exhibitionsFromDb;
        }

        /// <summary>
        /// Get randomized Id for SurpriseMe-button on Home Index.
        /// </summary>
        /// <returns> Returns a random ExhibitionId from exhibitions in db</returns>
        public async Task<int> RandomizedExhibitionId()
        {
            var exhibitionList = await GetAllExhibitionsOrderedByDate();
            int max = exhibitionList.Count();
            Random random = new Random();
            int randomInt = random.Next(max);

            return exhibitionList[randomInt].Id;
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
        /// Takes an Artist id and returns that artist's Exhibitions from Db (List<Exhibition>)
        /// </summary>
        /// <param name="id"></param>
        /// <returns name="exhibitions"></returns>
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

        /// <summary>
        /// Gets all Exhibitions from artist id that hasnt got an vernissage yet
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

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

        #region Artist

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
        /// Get artitems that is connected to an Artist
        /// </summary>
        /// <param name="artItem"></param>
        /// <returns></returns>
        public async Task<List<ArtItem>> GetArtItemsFromArtist(int id)
        {
            List<ArtItem> artItems = await db.ArtItems
            .Include(x => x.ArtItem_Tags)
            .Where(x => x.ArtistId == id)
            .ToListAsync();

            return artItems;
        }
        /// <summary>
        /// Returns a List <Artis> of all artists in Db
        /// </summary>
        /// <returns name="artists"></returns>
        public async Task<List<Artist>> GetAllArtists()
        {
            var artists = await db.Artists
               .Include(x => x.ArtItems).ThenInclude(y => y.ArtItem_Tags)
               .Include(x => x.Artist_Vernisages)
               .Include(x => x.Artist_Exhibitions)
               .Include(x => x.Artist_Tags).ToListAsync();
            return artists;
        }


        /// <summary>
        /// Returns an artist that is referenced in the ARTiculateUser
        /// </summary>
        /// <param name="id"></param>
        /// <returns name="artist"></returns>
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

        #endregion

        #region Tag

        /// <summary>
        /// Gets a tag from the database using a string
        /// </summary>
        /// <param name="artItem"></param>
        /// <returns></returns>
        public Tag GetTagByName(string tagToSearch)
        {
            Tag tag = db.Tags
                    .Where(x => x.TagName == tagToSearch)
                    .FirstOrDefault();

            if (tag == null)
            {
                tag = new Tag
                {
                    TagName = "notFound",
                    Id = 0
                };
            }

            return tag;
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

        #endregion

        #region ArtItem
        /// <summary>
        /// Takes id of Exhibition and returns List <ArtItem> of ArtItems related to Exhibition
        /// </summary>
        /// <param name="id"></param>
        /// <returns name="artItems"></returns>
        public async Task<List<ArtItem>> GetArtItemsFromExhibition(int id)
        {
            List<Exhibition_ArtItem> exhibition_ArtItems = await db.Exhibition_ArtItems
            .Include(x => x.ArtItems)
            .Where(x => x.ExhibitionId == id).ToListAsync();

            List<ArtItem> artItems = new List<ArtItem>();
            foreach (Exhibition_ArtItem x in exhibition_ArtItems)
            {
                artItems.Add(x.ArtItems);
            }

            return artItems;
        }
        /// <summary>
        /// Gets an ArtItem by Id from Db
        /// </summary>
        /// <param name="id"></param>
        /// <returns name="artItem"></returns>
        public async Task<ArtItem> GetArtItem(int id)
        {
            var artItem = await db.ArtItems
                .Include(x => x.Artist)
                .Include(x => x.ArtItem_Tags)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return artItem;
        }

        #endregion

        #endregion

        #region UPDATE

        /// <summary>
        /// Updates object of type Artitem in the database
        /// </summary>
        /// <param name="artItem"></param>
        /// <returns></returns>
        public async Task<ArtItem> UpdateArtItem(ArtItem artItem)
        {
            db.ArtItems.Update(artItem);
            await db.SaveChangesAsync();
            return artItem;
        }

        /// <summary>
        /// Updates object of type Exhibition in the database
        /// </summary>
        /// <param name="artItem"></param>
        /// <returns></returns>

        public async Task<Exhibition> UpdateExhibition(Exhibition exhibition)
        {
            db.Exhibitions.Update(exhibition);
            await db.SaveChangesAsync();
            return exhibition;
        }

        /// <summary>
        /// Updates object of type Vernissage in the database
        /// </summary>
        /// <param name="artItem"></param>
        /// <returns></returns>
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
