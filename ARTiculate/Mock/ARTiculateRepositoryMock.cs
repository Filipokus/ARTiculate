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
        public void GetMockData(ArtistContext db)
        {
            var fileMockdata = File.ReadAllText("Mock/Mockdata.json");
            var resultMockdata = JsonConvert.DeserializeObject<IEnumerable<Artist>>(fileMockdata);
            db.AddRange(resultMockdata);

            //var fileArtist = File.ReadAllText("Mock/Artist.json");
            //var resultArtist = JsonConvert.DeserializeObject<IEnumerable<Artist>>(fileArtist);
            //db.AddRange(resultArtist);

            //var fileArtItem = File.ReadAllText("Mock/ArtItem.json");
            //var resultArtItem = JsonConvert.DeserializeObject<IEnumerable<ArtItem>>(fileArtItem);
            //db.AddRange(resultArtItem);

            //var fileArtItem_Tag = File.ReadAllText("Mock/ArtItem_Tag.json");
            //var resultArtItem_Tag = JsonConvert.DeserializeObject<IEnumerable<ArtItem_Tag>>(fileArtItem_Tag);
            //db.AddRange(resultArtItem_Tag);

            //var fileExhibition = File.ReadAllText("Mock/Exhibition.json");
            //var resultExhibition = JsonConvert.DeserializeObject<IEnumerable<Exhibition>>(fileExhibition);
            //db.AddRange(resultExhibition);

            //var fileLink = File.ReadAllText("Mock/Link.json");
            //var resultLink = JsonConvert.DeserializeObject<IEnumerable<Link>>(fileLink);
            //db.AddRange(resultLink);

            //var fileStudio = File.ReadAllText("Mock/Studio.json");
            //var resultStudio = JsonConvert.DeserializeObject<IEnumerable<Studio>>(fileStudio);
            //db.AddRange(resultStudio);

            //var fileTag = File.ReadAllText("Mock/Tag.json");
            //var resultTag = JsonConvert.DeserializeObject<IEnumerable<Tag>>(fileTag);
            //db.AddRange(resultTag);

            //var fileVernisage = File.ReadAllText("Mock/Vernisage.json");
            //var resultVernisage = JsonConvert.DeserializeObject<IEnumerable<Vernisage>>(fileVernisage);
            //db.AddRange(resultVernisage);


            db.SaveChanges();



        }

       
    }
}
