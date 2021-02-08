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
        void GetMockData(ArtistContext db);

        Task<int> AddVernisageAsync(Vernisage vernisage);
        Task<Exhibition> AddExhibitionAsync(Exhibition exhibition);
        Task<Artist> AddArtistAsync(Artist artist);
        Task<Tag> AddTagAsync(Tag tag);

        Task<Vernisage> GetVernisage(int id);
        Task<List<Vernisage>> GetAllVernisagesOrderedByDate();
        Task<List<Vernisage>> GetAllVernisagesToCome();
        Task<List<Vernisage>> GetActiveVernisages();
        List<Tag> GetListOfTagsForSelectedVernisage(Vernisage vernisage);
        Task<Exhibition> GetExhibition(int id);
        Task<List<Exhibition>> GetAllExhibitionsOrderedByDate();
    
        List<Tag> GetListOfTagsForSelectedExhibition(Exhibition exhibition);
        Task<Artist> GetArtist(int id);
        
    }
}
