using ARTiculateDataAccessLibrary.DataAccess;
using ARTiculateDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Data
{
    public class ARTiculateRepository : IARTiculateRepository
    {
        public Task<Artist> AddArtistAsync(Artist artist)
        {
            throw new NotImplementedException();
        }

        public void AddArtist_VernisageAsync(Artist_Vernisage artist_Vernisage)
        {
            throw new NotImplementedException();
        }

        public Task<ArtItem> AddArtItem(ArtItem artItem)
        {
            throw new NotImplementedException();
        }

        public Task<Exhibition> AddExhibitionAsync(Exhibition exhibition)
        {
            throw new NotImplementedException();
        }

        public Task<Tag> AddTagAsync(Tag tag)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddVernisageAndReturnID(Vernisage vernisage, int artistID)
        {
            throw new NotImplementedException();
        }

        public Task<Vernisage> AddVernisageAsync(Vernisage vernisage)
        {
            throw new NotImplementedException();
        }

        public void CreateArtist_Vernisage(int vernisageId, int artistId)
        {
            throw new NotImplementedException();
        }

        public List<Exhibition> CreateListOfExhibitions(List<Exhibition> exhibitionsFromDb)
        {
            throw new NotImplementedException();
        }

        public List<Vernisage> CreateListOfVernissages(List<Vernisage> vernissagesFromDb)
        {
            throw new NotImplementedException();
        }

        public Task<List<Vernisage>> GetActiveVernisages()
        {
            throw new NotImplementedException();
        }

        public Task<List<Exhibition>> GetAllExhibitionsOrderedByDate()
        {
            throw new NotImplementedException();
        }

        public Task<List<Vernisage>> GetAllVernisagesOrderedByDate()
        {
            throw new NotImplementedException();
        }

        public Task<List<Vernisage>> GetAllVernisagesToCome()
        {
            throw new NotImplementedException();
        }

        public Task<Artist> GetArtist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ArtItem> GetArtItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Exhibition> GetExhibition(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Exhibition>> GetExhibitionsFromDbOrderedByDate()
        {
            throw new NotImplementedException();
        }

        public List<Tag> GetListOfTagsForSelectedExhibition(Exhibition exhibition)
        {
            throw new NotImplementedException();
        }

        public List<Tag> GetListOfTagsForSelectedVernisage(Vernisage vernisage)
        {
            throw new NotImplementedException();
        }

        public void GetMockData(ArtistContext db)
        {
            throw new NotImplementedException();
        }

        public Task<Vernisage> GetVernisage(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Vernisage>> GetVernissagesFromDbOrderedByDate()
        {
            throw new NotImplementedException();
        }

        public Task<ArtItem> UpdateArtItem(ArtItem artItem)
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


        //TODO: Metod/Metoder som returnerar en lista av exhibitions som inte har en vernissage

        //public async Task<List<Exhibition>> GetAllExhibitionsWithOutVernissageFromArtist(int id)
        //{
        //    List<Exhibition> allExhibitions = await GetAllExhibitionsFromArtistAsync(id);
        //    List<Exhibition> exhibitionsthatsAvailableToCreateVernissage = new List<Exhibition>();

        //    foreach (Exhibition exhibition in allExhibitions)
        //    {

        //    }

        //    return exhibitionsthatsAvailableToCreateVernissage;
        //}




        #endregion

        #region UPDATE

        public async Task<ArtItem> UpdateArtItem(ArtItem artItem)
        {
            throw new NotImplementedException();
        }

        public Task<Exhibition> UpdateExhibition(Exhibition exhibition)
        {
            throw new NotImplementedException();
        }

        public Task<Vernisage> UpdateVernissage(Vernisage vernissage)
        {
            throw new NotImplementedException();
        }
    }
}
