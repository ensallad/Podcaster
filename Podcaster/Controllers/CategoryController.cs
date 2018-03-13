using Podcaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Podcaster.Controllers
{
    public class CategoryController : Controller
    {
        private DatabaseContext db = new DatabaseContext();


        // GET: Category
        public ActionResult Index()
        {
            List<Podcast> podcastList = db.Podcasts.ToList();
            List<Podcast> podcastListCategory = new List<Podcast>();

            foreach (Podcast item in podcastList)
            {
                if (item.Category == "Comedy")
                { podcastListCategory.Add(item); }
            }

            return View(podcastListCategory);
        }

        public ActionResult Comedy()
        {

            List<Podcast> podcastList = db.Podcasts.ToList();
            List<Podcast> podcastListCategory = new List<Podcast>();

            foreach (Podcast item in podcastList)
            {
                if(item.Category=="Comedy")
                { podcastListCategory.Add(item); }
            }
        
            return View(podcastListCategory);
        }

        public ActionResult Education()
        {
            List<Podcast> podcastList = db.Podcasts.ToList();
            List<Podcast> podcastListCategory = new List<Podcast>();

            foreach (Podcast item in podcastList)
            {
                if (item.Category == "Education")
                { podcastListCategory.Add(item); }
            }

            return View(podcastListCategory);
        }

        public ActionResult News()
        {
            List<Podcast> podcastList = db.Podcasts.ToList();
            List<Podcast> podcastListCategory = new List<Podcast>();

            foreach (Podcast item in podcastList)
            {
                if (item.Category == "News")
                { podcastListCategory.Add(item); }
            }

            return View(podcastListCategory);
        }

        public ActionResult Science()
        {
            List<Podcast> podcastList = db.Podcasts.ToList();
            List<Podcast> podcastListCategory = new List<Podcast>();

            foreach (Podcast item in podcastList)
            {
                if (item.Category == "Science")
                { podcastListCategory.Add(item); }
            }

            return View(podcastListCategory);
        }

        public ActionResult Society()
        {
            List<Podcast> podcastList = db.Podcasts.ToList();
            List<Podcast> podcastListCategory = new List<Podcast>();

            foreach (Podcast item in podcastList)
            {
                if (item.Category == "Society")
                { podcastListCategory.Add(item); }
            }

            return View(podcastListCategory);
        }

        public ActionResult Technology()
        {
            List<Podcast> podcastList = db.Podcasts.ToList();
            List<Podcast> podcastListCategory = new List<Podcast>();

            foreach (Podcast item in podcastList)
            {
                if (item.Category == "Technology")
                { podcastListCategory.Add(item); }
            }

            return View(podcastListCategory);
        }

        public ActionResult Tv()
        {
            List<Podcast> podcastList = db.Podcasts.ToList();
            List<Podcast> podcastListCategory = new List<Podcast>();

            foreach (Podcast item in podcastList)
            {
                if (item.Category == "Tv")
                { podcastListCategory.Add(item); }
            }

            return View(podcastListCategory);
        }

        public ActionResult Sport()
        {
            List<Podcast> podcastList = db.Podcasts.ToList();
            List<Podcast> podcastListCategory = new List<Podcast>();

            foreach (Podcast item in podcastList)
            {
                if (item.Category == "Sport")
                { podcastListCategory.Add(item); }
            }

            return View(podcastListCategory);
        }
    }
}