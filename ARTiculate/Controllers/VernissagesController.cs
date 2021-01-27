using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Controllers
{
    public class VernissagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
