using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DungeonSlayers.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Active()
        {
            ViewBag.Message = "Hero Sheet for your current active character.";

            return View();
        }

        public ActionResult Characters()
        {
            ViewBag.Message = "This is a list of all Character Templates.";

            return View();
        }
    }
}