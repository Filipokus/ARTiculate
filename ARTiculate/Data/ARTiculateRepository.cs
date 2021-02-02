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

        /// <summary>
        /// Returns an artist from the db by taking the id (int) as input.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Artist GetArtist(int id)
        {
            var artist = db.Artists
                .Include(x => x.ArtItems).ThenInclude(y => y.ArtItem_Tags)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return artist;
        }


        /// <summary>
        /// Returns a List containing all vernissages in db, sorted by date.
        /// </summary>
        /// <returns></returns>
        public List<Vernisage> GetAllVernisagesOrderedByDate()
        {
            List<Vernisage> vernisages = new List<Vernisage>();

            foreach (var item in db.Vernisages)
                vernisages.Add(item);
            
            vernisages
                .OrderBy(x => x.DateTime);

            return vernisages;
        }




        public void GetMockData(ArtistContext db)
        {
            throw new NotImplementedException();
        }
    }
}
