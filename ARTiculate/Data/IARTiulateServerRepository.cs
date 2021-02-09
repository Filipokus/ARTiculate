using ARTiculate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Data
{
    public interface IARTiulateServerRepository
    {
        public Task<string> UploadPictureToServer(ArtItemViewModel imageModel);
    }
}
