using ARTiculateDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Models
{
    public class ExhibitionViewModel
    {
        public List<Exhibition> Exhibitions { get; set; } = new List<Exhibition>();
        public List<Exhibition> NewlyAddedExhibitions { get; set; }
        public List<Exhibition> ExhibitionsByTagName { get; set; }
        public string TagName { get; set; } = "keramik";


        public ExhibitionViewModel()
        {

        }

        public ExhibitionViewModel(List<Exhibition> exhibitions)
        {
            Exhibitions = exhibitions;
            NewlyAddedExhibitions = GetNewlyAddedExhibitionsForView(exhibitions);
            ExhibitionsByTagName = SortExhibitionsByTagName(TagName, exhibitions);
        }


        /// <summary>
        /// Adds six Exhibitions to a new list and returns a list with exhibitions with four pictures
        /// </summary>
        /// <param name="exhibitions"></param>
        /// <returns></returns>
        public List<Exhibition> GetNewlyAddedExhibitionsForView(List<Exhibition> exhibitions)
        {
            List<Exhibition> SixNewlyAddedExhibitions = AddMaxSixExhibtionsToList(exhibitions);

            if (CheckIfExhibitionContainsFourPosters(SixNewlyAddedExhibitions))
            {
                return SixNewlyAddedExhibitions;
            }
            else
            {
                var exhibitionsWithFourArtItems = CreateNewListWithFourPictures(SixNewlyAddedExhibitions);
                return exhibitionsWithFourArtItems;
            }
        }

        /// <summary>
        /// Adds the first six Exhibitons in a List<Exhibition> to a new list
        /// </summary>
        /// <param name="exhibitions"></param>
        /// <returns>List<Exhibition> with a maximum of six exhibitions</returns>
        public List<Exhibition> AddMaxSixExhibtionsToList(List<Exhibition> exhibitions)
        {
            var listOfSixExhibitions = new List<Exhibition>();

            for (int i = exhibitions.Count - 1; i > 0; i--)
            {
                listOfSixExhibitions.Add(exhibitions[i]);
                if (listOfSixExhibitions.Count == 6)
                {
                    break;
                }
            }

            return listOfSixExhibitions;
        }

        /// <summary>
        /// Creates a new list and adds four Exhibition_ArtItems to the Exhibition
        /// </summary>
        /// <param name="exhibitions"></param>
        /// <returns>List of exhibitions with four pictures</returns>
        public List<Exhibition> CreateNewListWithFourPictures(List<Exhibition> exhibitions)
        {
            List<Exhibition> exhibitionsWithFourPosters = new List<Exhibition>();

            foreach (var exhibition in exhibitions)
            {
                var newExhibition = exhibition;
                List<Exhibition_ArtItem> listOfExhibitionsWithFourArtItems = new List<Exhibition_ArtItem>();

                if (exhibition.Exhibition_ArtItem.Count >= 4)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        listOfExhibitionsWithFourArtItems.Add(exhibition.Exhibition_ArtItem[i]);
                    }
                    newExhibition.Exhibition_ArtItem = listOfExhibitionsWithFourArtItems;
                    exhibitionsWithFourPosters.Add(newExhibition);
                }
            }

            return exhibitionsWithFourPosters;
        }

        /// <summary>
        /// Loops through a list of Exhibtions. Returns False if the list contains more or less then 4 obejcts
        /// </summary>
        /// <param name="exhibitions"></param>
        /// <returns>True or false</returns>
        public bool CheckIfExhibitionContainsFourPosters(List<Exhibition> exhibitions)
        {
            foreach (var exhibition in exhibitions)
            {
                if (exhibition.Exhibition_ArtItem.Count != 4)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Creates a new list with all Exhibitions that is tagged with the specified name of the tag
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="exhibitions"></param>
        /// <returns>List<Exhibition> listBySearchedTagName</returns>
        public List<Exhibition> SortExhibitionsByTagName(string tagName, List<Exhibition> exhibitions)
        {
            List<Exhibition> listBySearchedTagName = new List<Exhibition>();

            foreach (var exhibition in exhibitions)
            {
                foreach (var tag in exhibition.Exhibition_Tags)
                {
                    if (tagName.Equals(tag.Tag.TagName))
                    {
                        listBySearchedTagName.Add(exhibition);
                        break;
                    }
                }
            }

            return listBySearchedTagName;
        }
    }
}
