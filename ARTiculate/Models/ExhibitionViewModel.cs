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
        public List<Exhibition> ExhibitionsByTagName { get; set; } = new List<Exhibition>();


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
            NewlyAddedAxhibitions();
           // ExhibitionsByTagName = SortExhibitionsByTagName("rymden");
        }

        private void NewlyAddedAxhibitions()
        {
            for (int i = 0; (i < 6) && (i < Exhibitions.Count); i++)
            {
                NewlyAddedExhibitions.Add(Exhibitions[i]);
            }
        }

        public List<Exhibition> SortExhibitionsByTagName(string tagName, List<Exhibition> testList)
        {
            List<Exhibition> list = new List<Exhibition>();

            foreach (var exhibition in testList)
            {
                foreach (var tag in exhibition.Exhibition_Tags)
                {
                    if (tagName.Equals(tag.Tag.TagName))
                    {
                        list.Add(exhibition);
                        break;
                    }
                }
            }

            return list;
        }
    }
}
