using CharliesHouseWeb.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharliesHouseWeb.Controllers
{
    [PagUserLogado]

    public class Restrito : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
