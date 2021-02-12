using ARTiculate.Models;
using ARTiculateDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Data
{
    public interface IARTiulateServerRepository
    {
        public Task<string> UploadPictureToServer(ImageModel imageModel);
        public double CalculateDuration(DateTime startTime, DateTime endTime);
        public List<ArtItem> GetSelectedArtItems(List<ArtItem> allArtItems, List<bool> selectedArtItems);
    }
}
