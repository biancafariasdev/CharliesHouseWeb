using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharliesHouseWeb.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NewClient()
        {
            return View();
        }
        public IActionResult EditClient()
        {
            return View();
        }
        public IActionResult DeleteClientConfirm()
        {
            return View();
        }
    }
}
