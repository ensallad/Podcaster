using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Xml;
using System.Collections.Generic;
using Podcaster.Models;
using System.Xml.Linq;
using System.Net;
using System.Text;

namespace Podcaster.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
       {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PlayingPage()
        {
            ViewBag.Message = "Your Podcast playing page.";

            List<PodcastEpisodeModel> podEpisode = new List<PodcastEpisodeModel>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://deadlysiriussxm.libsyn.com/rss");

            foreach (System.Xml.XmlNode temp in xmlDoc.DocumentElement.SelectNodes("channel"))
            {
                var mainTitle = temp.SelectSingleNode("title");
                var main = mainTitle.InnerText;

                podEpisode.Add(new PodcastEpisodeModel
                {
                    Description = main
                });

            }
            foreach (System.Xml.XmlNode temp in xmlDoc.DocumentElement.SelectNodes("channel/item"))
            {
                var mainTitle = temp.SelectSingleNode("title");
                var main = mainTitle.InnerText;

                var mainPub = temp.SelectSingleNode("pubDate");
                var PubDt = mainPub.InnerText;

                var epiUrl = "";
                var enclosure = temp.SelectSingleNode("enclosure");
                if (enclosure != null) { epiUrl = enclosure.Attributes["url"].Value; }
                var media = temp.SelectSingleNode("media");
                if (media != null)
                { epiUrl = media.Attributes["url"].Value; }

                string desc = null;
                var description = temp.SelectSingleNode("description");
                if (description != null)
                {
                    desc = description.InnerText;
                }
                else
                {
                    desc = null;
                }

                podEpisode.Add(new PodcastEpisodeModel
                {
                    episodeTitle = main,
                    PublicationDate = PubDt,
                    episodeUrl = epiUrl,
                    Description = desc
                });


            }

            return View(podEpisode);
        }
    }
}