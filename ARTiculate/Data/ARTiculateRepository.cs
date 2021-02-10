using ARTiculate.Areas.Identity.Data;
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

        /// <summary>
        /// Creates an Artist object from a ArticulateUser
        /// </summary>
        /// <param name="artist"></param>
        /// <returns></returns>
        public Artist CreateArtistFromARTiculateUser(ARTiculateUser user)
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

        public async Task<List<Exhibition>> GetAllExhibitionsFromArtistAsync(int id)
        {
            throw new NotImplementedException();
        }

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

        public Task<List<Exhibition>> GetAllExhibitionsWithOutVernissageFromArtist(int id)
        {
            throw new NotImplementedException();
        }
    }
}
