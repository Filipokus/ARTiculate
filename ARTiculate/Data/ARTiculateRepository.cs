﻿using ARTiculateDataAccessLibrary.DataAccess;
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
            };
            await db.AddAsync(artist);
            db.SaveChanges();
            return artist;
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
        public async Task<List<Tag>> GetListOfTagsForSelectedVernisage(Vernisage vernisage)
        {
            List<Tag> tags = new List<Tag>();

            foreach (var item in vernisage.Vernisage_Tags)
            {
                tags.Add(item.Tag);
            }

            await Task.Delay(0);

            return tags;
        }

        /// <summary>
        /// Returns an artist from the db by taking the id (int) as input.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Artist> GetArtist(int id)
        {
            var artist = db.Artists
                .Include(x => x.ArtItems).ThenInclude(y => y.ArtItem_Tags)
                .Include(x => x.Artist_Vernisages)
                .Include(x => x.Artist_Exhibitions)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            await Task.Delay(0);

            return artist;
        }

        /// <summary>
        /// Returns a List containing all vernissages in db, sorted by date.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Vernisage>> GetAllVernisagesOrderedByDate()
        {
            List<Vernisage> vernisages = new List<Vernisage>();

            foreach (var vernisage in db.Vernisages)
            {
                vernisages.Add(vernisage);
            }

            vernisages
                .OrderBy(x => x.DateTime);

            await Task.Delay(0);

            return vernisages;
        }

        /// <summary>
        /// Method "Get" vernissage, input id and returns a vernissage. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Vernisage> GetVernisage(int id)
        {
            var vernisage = db.Vernisages
              .Include(x => x.Artist_Vernisages)
              .Include(y => y.Vernisage_Tags).ThenInclude(x => x.Tag)
              .Where(x => x.Id == id)
              .FirstOrDefault();

            await Task.Delay(0);
            return vernisage;
        }
        #endregion

        #region UPDATE

        #endregion

        #region DELETE

        #endregion

          
      
    }
}
