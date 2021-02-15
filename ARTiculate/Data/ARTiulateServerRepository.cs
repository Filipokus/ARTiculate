using ARTiculate.Models;
using ARTiculateDataAccessLibrary.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Data
{
    public class ARTiulateServerRepository : IARTiulateServerRepository
    {
        
        private IWebHostEnvironment hostEnvironment;

        #region CONSTRUCT
        public ARTiulateServerRepository(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }
        /// <summary>
        /// Ctor for test class to avoid an empty ctor
        /// </summary>
        /// <param name="test"></param>
        public ARTiulateServerRepository(string test) 
        {
            
        }
        #endregion

        public async Task<string> UploadPictureToServer(ImageModel imageModel)
        {
            string serverPath = hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(imageModel.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            imageModel.FileName = fileName = fileName + DateTime.Now.ToString("yyMMddhhmmssffff") + extension;
            string path = Path.Combine(serverPath + "/UploadedImages", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await imageModel.ImageFile.CopyToAsync(fileStream);
            }
            int skippableURL = serverPath.Length;
            string newURL = path.Substring(skippableURL);
            return "~" + newURL;
        }

        // TODO förenkla metoden
        /// <summary>
        /// Takes two in data parameters as DateTime and returns the difference
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTimeRaw"></param>
        /// <returns>double timespan</returns>
        public double CalculateDuration(DateTime startTime, DateTime endTimeRaw)
        {
            var year = startTime.Year;
            var month = startTime.Month;
            var day = startTime.Day;

            DateTime endTime = new DateTime(year, month, day, endTimeRaw.Hour, endTimeRaw.Minute, endTimeRaw.Second);

            double duration = 0;

            if (startTime.Hour > endTime.Hour)
            {
                double timeleftTo00 = 24 - startTime.Hour;
                double timeawayfrom00 = endTime.Hour;
                double hourdiff = timeleftTo00 + timeawayfrom00;

                double mindiff = 0;

                if (startTime.Minute > endTime.Minute)
                {
                    mindiff = (endTime.Minute - startTime.Minute) / 60;
                }
                else if (endTime.Minute > startTime.Minute)
                {
                    mindiff = (endTime.Minute + startTime.Minute) / 60;
                }

                duration = hourdiff + mindiff;
            }
            else
            {
                TimeSpan diff = endTime.Subtract(startTime);
                duration = diff.TotalHours;
            }

            return duration;
        }

        public List<ArtItem> GetSelectedArtItems(List<ArtItem> allArtItems, List<bool> selectedArtItems)
        {
            List<ArtItem> theSelectedArtItems = new List<ArtItem>();

            for (int i = 0; i < selectedArtItems.Count; i++)
            {
                if (selectedArtItems[i])
                {
                    theSelectedArtItems.Add(allArtItems[i]);
                }
            }
            return theSelectedArtItems;
        }
    }
}
