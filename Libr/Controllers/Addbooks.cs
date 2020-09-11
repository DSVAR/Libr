using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Libr.Controllers
{
    public class Addbooks : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
