using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTiculate.Controllers
{
    public class ExhibitionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Exhibition(/*int id*/)
        {
            return View(/*id*/);
        }
    }
}
