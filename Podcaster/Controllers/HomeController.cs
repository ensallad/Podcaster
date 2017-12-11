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
            string PodcastName;

            List<PodcastEpisodeModel> podEpisode = new List<PodcastEpisodeModel>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("https://rss.itunes.apple.com/api/v1/us/podcasts/top-podcasts/all/10/explicit.rss");

            foreach (System.Xml.XmlNode temp in xmlDoc.DocumentElement.SelectNodes("channel"))
            {
                var mainTitle = temp.SelectSingleNode("title").InnerText;

                PodcastName = mainTitle;
                podEpisode.Add(new PodcastEpisodeModel
                {
                    //Description = mainTitle
                    PodcastName = mainTitle
                });

            }
            //ViewBag.PodcastName = PodcastName;
            foreach (System.Xml.XmlNode temp in xmlDoc.DocumentElement.SelectNodes("channel/item"))
            {
                var mainTitle = temp.SelectSingleNode("title").InnerText; ;

                var PubDt = temp.SelectSingleNode("pubDate").InnerText;

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
                    episodeTitle = mainTitle,
                    PublicationDate = PubDt,
                    episodeUrl = epiUrl,
                    Description = desc
                });


            }
            //ViewBag.ListEpisode = podEpisode;
            podEpisode.RemoveAt(0);
            return View(podEpisode);
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}