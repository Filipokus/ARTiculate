using ARTiculate.Data;
using ARTiculateDataAccessLibrary.DataAccess;
using ARTiculateDataAccessLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Mock
{
    public class ARTiculateRepositoryMock : IARTiculateRepository
    {
        public Task<List<Tag>> GetListOfTagsForSelectedVernisage(Vernisage vernisage)
        {
            throw new NotImplementedException();
        }

        public void GetMockData(ArtistContext db)
        {
            //var fileArtist = File.ReadAllText("Mock/Artist.json");
            //var resultArtist = JsonConvert.DeserializeObject<IEnumerable<Artist>>(fileArtist);
            //db.AddRange(resultArtist);
            //db.SaveChanges();
            
            //var fileArtItem = File.ReadAllText("Mock/ArtItem.json");
            //var resultArtItem = JsonConvert.DeserializeObject<IEnumerable<ArtItem>>(fileArtItem);
            //db.AddRange(resultArtItem);
            //db.SaveChanges();
            
            //var fileExhibition = File.ReadAllText("Mock/Exhibition.json");
            //var resultExhibition = JsonConvert.DeserializeObject<IEnumerable<Exhibition>>(fileExhibition);
            //db.AddRange(resultExhibition);
            //db.SaveChanges();
            
            //var fileLink = File.ReadAllText("Mock/Link.json");
            //var resultLink = JsonConvert.DeserializeObject<IEnumerable<Link>>(fileLink);
            //db.AddRange(resultLink);
            //db.SaveChanges();
            
            //var fileStudio = File.ReadAllText("Mock/Studio.json");
            //var resultStudio = JsonConvert.DeserializeObject<IEnumerable<Studio>>(fileStudio);
            //db.AddRange(resultStudio);
            //db.SaveChanges();
            
            //var fileTag = File.ReadAllText("Mock/Tag.json");
            //var resultTag = JsonConvert.DeserializeObject<IEnumerable<Tag>>(fileTag);
            //db.AddRange(resultTag);
            //db.SaveChanges();
            
            //var fileVernisage = File.ReadAllText("Mock/Vernisage.json");
            //var resultVernisage = JsonConvert.DeserializeObject<IEnumerable<Vernisage>>(fileVernisage);
            //db.AddRange(resultVernisage);
            //db.SaveChanges();
            
            //var fileArtItem_Tag = File.ReadAllText("Mock/ArtItem_Tag.json");
            //var resultArtItem_Tag = JsonConvert.DeserializeObject<IEnumerable<ArtItem_Tag>>(fileArtItem_Tag);
            //db.AddRange(resultArtItem_Tag);
            //db.SaveChanges();

            //var fileArtist_Exhibition = File.ReadAllText("Mock/Artist_Exhibition.json");
            //var resultArtist_Exhibition = JsonConvert.DeserializeObject<IEnumerable<Artist_Exhibition>>(fileArtist_Exhibition);
            //db.AddRange(resultArtist_Exhibition);
            //db.SaveChanges();

            //var fileArtist_Tag = File.ReadAllText("Mock/Artist_Tag.json");
            //var resultArtist_Tag = JsonConvert.DeserializeObject<IEnumerable<Artist_Tag>>(fileArtist_Tag);
            //db.AddRange(resultArtist_Tag);
            //db.SaveChanges();

            //var fileExhibition_Tag = File.ReadAllText("Mock/Exhibition_Tag.json");
            //var resultExhibition_Tag = JsonConvert.DeserializeObject<IEnumerable<Exhibition_Tag>>(fileExhibition_Tag);
            //db.AddRange(resultExhibition_Tag);
            //db.SaveChanges();

            //var fileArtist_Vernisage = File.ReadAllText("Mock/Artist_Vernisage.json");
            //var resultArtist_Vernisage = JsonConvert.DeserializeObject<IEnumerable<Artist_Vernisage>>(fileArtist_Vernisage);
            //db.AddRange(resultArtist_Vernisage);
            //db.SaveChanges();

            //var fileVernisage_Tag = File.ReadAllText("Mock/Vernisage_Tag.json");
            //var resultVernisage_Tag = JsonConvert.DeserializeObject<IEnumerable<Vernisage_Tag>>(fileVernisage_Tag);
            //db.AddRange(resultVernisage_Tag);
            //db.SaveChanges();
        }
    }
}
