using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsBG.Controllers
{
    public class ForUsController : Controller
    {
        public IActionResult Info()
        {
            return View();
        }
    }
}
