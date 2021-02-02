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

        public ARTiculateRepository(ArtistContext context)
        {
            db = context;
        }





        public void GetMockData(ArtistContext db)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method "Get" vernissage, input id and returns a vernissage. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Vernisage GetVernisage(int id)
        {
            var vernisage = db.Vernisages
              .Include(x => x.Artist_Vernisages)
              .Include(y => y.Vernisage_Tags)
              .Where(x => x.Id == id)

              .FirstOrDefault();
            return vernisage;
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
    }
}
