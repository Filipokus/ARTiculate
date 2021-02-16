using ARTiculate.Areas.Identity.Data;
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


        public Task<List<ArtItem_Tag>> AddArtItem_Tags(string tagsRaw, int id);
        Task<Vernisage> AddVernisageAsync(Vernisage vernisage);
        Task<Exhibition> AddExhibitionAsync(Exhibition exhibition);
        Task<Artist> AddArtistAsync(Artist artist);
        Task<Tag> AddTagAsync(Tag tag);
        Task<ArtItem> AddArtItem(ArtItem artItem);

        Task<Vernisage> GetVernisage(int id);
        Task<List<Vernisage>> GetAllVernisagesOrderedByDate();
        Task<List<Vernisage>> GetAllVernisagesToCome();
        Task<List<Vernisage>> GetLiveVernisages();
        Task<List<Vernisage>> GetActiveVernisages();
        List<Tag> GetListOfTagsForSelectedVernisage(Vernisage vernisage);
        Task<Exhibition> GetExhibition(int id);
        Task<List<Exhibition>> GetAllExhibitionsOrderedByDate();
    
        List<Tag> GetListOfTagsForSelectedExhibition(Exhibition exhibition);
        Task<List<ArtItem>> GetArtItemsFromExhibition(int id);
        Task<Artist> GetArtist(int id);
        Task<Artist> GetArtistFromARTiculateUser(ARTiculateUser user);
        public Task<List<Exhibition>> GetAllExhibitionsFromArtistAsync(int id);
        public Task<List<Exhibition>> GetAllExhibitionsWithOutVernissageFromArtist(int id);
        Task<List<ArtItem>> GetArtItemsFromArtist(int id);
        Task<int> AddVernisageAndReturnID(Vernisage vernisage, int artistID);
        void AddArtist_VernisageAsync(Artist_Vernisage artist_Vernisage);
        void CreateArtist_Vernisage(int vernisageId, int artistId);
        public Task CreateArtist_Exhibition(int exhibitionId, int artistId);
        public Task AddArtist_ExhibitionAsync(Artist_Exhibition artist_Exhibition);
        public Task<Exhibition_ArtItem> AddArtItemToExhibition(Exhibition_ArtItem exhibition_ArtItem);
        public Task CreateExhibition_ArtItemsAsync(List<ArtItem> artItems, int exhibitionId);
        public Task<ArtItem> GetArtItem(int id);
        Task<List<Vernisage>> GetVernissagesFromDbOrderedByDate();
        List<Vernisage> CreateListOfVernissages(List<Vernisage> vernissagesFromDb);
        Task<List<Exhibition>> GetExhibitionsFromDbOrderedByDate();
        List<Exhibition> CreateListOfExhibitions(List<Exhibition> exhibitionsFromDb);
        Task<ArtItem> UpdateArtItem(ArtItem artItem);
        Task<Exhibition> UpdateExhibition(Exhibition exhibition);
        Task<Vernisage> UpdateVernissage(Vernisage vernissage);

        Artist CreateArtistFromARTiculateUser(ARTiculateUser user);

        Task<List<Artist>> GetAllArtists();
    }
}
