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
        public List<Exhibition> NewlyAddedExhibitions { get; set; } = new List<Exhibition>();
        public List<Exhibition> ExhibitionsByTagName { get; set; }
        public string TagName { get; set; }


        public ExhibitionViewModel()
        {

        }

        public ExhibitionViewModel(Exhibition exhibition)
        {
            Exhibition = exhibition;
        }

        public ExhibitionViewModel(List<Exhibition> exhibitions)
        {
            Exhibitions = exhibitions;
            GetNewlyAddedExhibitions();
            ExhibitionsByTagName = SortExhibitionsByTagName(TagName, exhibitions);
        }

        /// <summary>
        /// Updates the list NewlyAddedExhibitions with the 6 most recent added Exhibitions.
        /// </summary>
        private void GetNewlyAddedExhibitions()
        {
            for (int i = 0; (i < 6) && (i < Exhibitions.Count); i++)
            {
                NewlyAddedExhibitions.Add(Exhibitions[i]);
            }
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
