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
        ArtistContext db;

        public ARTiculateRepository(ArtistContext context)
        {
            db = context;
        }





        public void GetMockData(ArtistContext db)
        {
            throw new NotImplementedException();
        }
    }
}
