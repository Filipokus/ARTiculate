using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Models
{
    public class BaseViewModel
    {
        public string RandomizedController { get; set; } = "Exhibitions";

        public string RandomizedAction { get; set; } = "Exhibition";

        public int RandomizedId { get; set; } = 1;
    }
}
