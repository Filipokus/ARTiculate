using ARTiculate.Data;
using ARTiculateDataAccessLibrary.DataAccess;

namespace ARTiculate.Models
{
    public class BaseViewModel
    {
        public int RandomizedId { get; set; }

        public BaseViewModel(int id)
        {
            RandomizedId = id;
        }

        public BaseViewModel()
        {

        }
    }
}
