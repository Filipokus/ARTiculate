using ARTiculateDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Models
{
    public class ExhibitionViewModel
    {
        public Exhibition Exhibition { get; set; }
        public List<Exhibition> Exhibitions { get; set; } = new List<Exhibition>();
        public List<Exhibition> NewlyAddedExhibitions { get; set; }
        public List<Exhibition> ExhibitionsByTagName { get; set; }
        public string TagName { get; set; }


        public ExhibitionViewModel()
        {

        }

        public ExhibitionViewModel(Exhibition exhibition)
        {
            Exhibition = exhibition;
        }

        //public ExhibitionViewModel(List<Exhibition> exhibitions)
        //{
        //    Exhibitions = exhibitions;
        //    GetNewlyAddedExhibitions();
        //    ExhibitionsByTagName = SortExhibitionsByTagName(TagName, exhibitions);
        //}

        public ExhibitionViewModel(List<Exhibition> exhibitions)
        {
            Exhibitions = exhibitions;
            NewlyAddedExhibitions = GetNewlyAddedExhibitionsForView(exhibitions);
            ExhibitionsByTagName = SortExhibitionsByTagName(TagName, exhibitions);
        }

        public List<Exhibition> GetNewlyAddedExhibitionsForView(List<Exhibition> exhibitions)
        {
            List<Exhibition> listOfNewlyAddedExhibitions = new List<Exhibition>();

            for (int i = 0; (i < 6) && (i < exhibitions.Count); i++)
            {
                listOfNewlyAddedExhibitions.Add(exhibitions[i]);
            }

            if (CheckIfFourPosters(listOfNewlyAddedExhibitions))
            {
                return listOfNewlyAddedExhibitions;
            }
            else
            {
                var list = FourPosters(listOfNewlyAddedExhibitions);
                return list;
            }

        }

        public List<Exhibition> FourPosters(List<Exhibition> exhibitions)
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


        public bool CheckIfFourPosters(List<Exhibition> exhibitions)
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
        /// Updates the list NewlyAddedExhibitions with the 6 most recent added Exhibitions.
        /// </summary>
        //public void GetNewlyAddedExhibitions()
        //{
        //    for (int i = 0; (i < 6) && (i < Exhibitions.Count); i++)
        //    {
        //        NewlyAddedExhibitions.Add(Exhibitions[i]);
        //    }
        //}

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
