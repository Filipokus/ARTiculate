﻿using ARTiculateDataAccessLibrary.DataAccess;
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
        List<Tag> GetListOfTagsForSelectedVernisage(Vernisage vernisage);
        void GetMockData(ArtistContext db);
        Task<Vernisage> GetVernisage(int id);
        Task<Artist> GetArtist(int id);
        Task<List<Vernisage>> GetAllVernisagesOrderedByDate();
        Task<Tag> CreateTag(string tagname);

    }
}