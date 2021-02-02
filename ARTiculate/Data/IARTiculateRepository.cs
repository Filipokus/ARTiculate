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
        void GetMockData(ArtistContext db);
        Artist GetArtist(int id);
        List<Vernisage> GetAllVernisagesOrderedByDate();

    }
}
