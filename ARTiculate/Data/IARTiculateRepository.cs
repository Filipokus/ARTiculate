using ARTiculateDataAccessLibrary.DataAccess;
using ARTiculateDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Data
{
    public interface IARTiculateRepository
    {
        List<Tag> GetListOfTagsForSelectedVernisage(Vernisage vernisage);
        void GetMockData(ArtistContext db);
        Task<Vernisage> GetVernisage(int id);
        Task<Artist> GetArtist(int id);
        Task<List<Vernisage>> GetAllVernisagesOrderedByDate();
        Task<Tag> AddTagAsync(Tag tag);
        Task<Artist> AddArtistAsync(Artist artist);
        Task<int> AddVernisageAsync(Vernisage vernisage);
    }
}
