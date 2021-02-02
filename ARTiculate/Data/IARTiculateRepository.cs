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
        Task<List<Tag>> GetListOfTagsForSelectedVernisage(Vernisage vernisage);
        void GetMockData(ArtistContext db);
    }
}
