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

            return View(podEpisode);
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public ActionResult PlayingPage(string rssFeed,string imgUrl, string episodeName)
        {
            string PodcastName = "";
            string admittedEpisode = "";

            List<PodcastEpisodeModel> podCast = new List<PodcastEpisodeModel>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(rssFeed);
            foreach (System.Xml.XmlNode temp in xmlDoc.DocumentElement.SelectNodes("channel"))
            {
                var mainTitle = temp.SelectSingleNode("title").InnerText;

                PodcastName = mainTitle;
                if (PodcastName != "") { 
                podCast.Add(new PodcastEpisodeModel
                {
                    //Description = mainTitle
                    PodcastName = mainTitle
                });
            }
        }
            ViewBag.PodcastName = PodcastName;
            ViewBag.rss = rssFeed;
            foreach (System.Xml.XmlNode temp in xmlDoc.DocumentElement.SelectNodes("channel/item"))
            {
                var mainTitle = temp.SelectSingleNode("title").InnerText; ;
                //var main = mainTitle.InnerText;

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


                if (mainTitle!=null && PubDt != null) {

                    podCast.Add(new PodcastEpisodeModel
                {
                    episodeTitle = mainTitle,
                    PublicationDate = PubDt,
                    episodeUrl = epiUrl,
                    Description = desc
                });
            }

        }


            //get the information for the selected podcast episode
            var newEpisodeDescription = "";
            if (episodeName!= null) {
                foreach (System.Xml.XmlNode temp in xmlDoc.DocumentElement.SelectNodes("channel/item"))
                {
                    if (episodeName == temp.SelectSingleNode("title").InnerText)
                    {
                        var enclosure = temp.SelectSingleNode("enclosure");
                        if (enclosure != null) { admittedEpisode = enclosure.Attributes["url"].Value; }
                        var media = temp.SelectSingleNode("media");
                        if (media != null)
                        { admittedEpisode = media.Attributes["url"].Value; }

                        var description = temp.SelectSingleNode("description");
                        if (description != null)
                        {
                            newEpisodeDescription = description.InnerText;
                        }
                        else
                        {
                            newEpisodeDescription = "";
                        }
                    }
                }
            }

            
            var imageUrl = "lars";
            if(imgUrl != null)
            { imageUrl = imgUrl; }
            
            //get the latest episode information to the player in playingpage
            var firstItem = podCast[1]; 
            var firstUrl = firstItem.episodeUrl;
            var firstEpisodeTitle = firstItem.episodeTitle;
            var firstEpisodeDescription = firstItem.Description;
  

            ViewBag.newImageUrl = imageUrl;

            ViewBag.ListEpisode = podCast;
            ViewBag.choosenEpisodeUrl = firstUrl;
            ViewBag.choosenEpisodeTitle = firstEpisodeTitle;
            ViewBag.choosenEpisodeDescription = firstEpisodeDescription;
            if (admittedEpisode != "")
            { ViewBag.choosenEpisodeUrl = admittedEpisode;
               ViewBag.choosenEpisodeTitle = episodeName;
               ViewBag.choosenEpisodeDescription = newEpisodeDescription; 
            }


            return View(podCast);
        }



        public ActionResult GetPodEpisodes(string podRss)
        {

            return View();

            //return PartialView("podResults", podEpisodeTitle);
        }





    }
}