using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Podcaster.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return Comedy();
        }

        public ActionResult Comedy()
        {

            return View();
        }

        public ActionResult Education()
        {
            return View();
        }

        public ActionResult News()
        {
            return View();
        }

        public ActionResult Science()
        {
            return View();
        }

        public ActionResult Society()
        {
            return View();
        }

        public ActionResult Technology()
        {
            return View();
        }

        public ActionResult Tv()
        {
            return View();
        }

        public ActionResult Sport()
        {
            return View();
        }
    }
}