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
        Task<Artist> CreateArtist(string fristname, string lastname);
        Task<List<Tag>> GetListOfTagsForSelectedVernisage(Vernisage vernisage);
        void GetMockData(ArtistContext db);
        Vernisage GetVernisage(int id);
        Task<Artist> GetArtist(int id);
        List<Vernisage> GetAllVernisagesOrderedByDate();

    }
}
