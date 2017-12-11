using Podcaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace Podcaster.Controllers
{
    public class PlayingPageController : Controller
    {
        // GET: PlayingPage
        public ActionResult Index(string rssFeed, string imgUrl, string episodeName)
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
                    if (PodcastName != "")
                    {
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


                    if (mainTitle != null && PubDt != null)
                    {

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
                if (episodeName != null)
                {
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

                podCast.RemoveAt(0);

                var imageUrl = "lars";
                if (imgUrl != null)
                { imageUrl = imgUrl; }

                //get the latest episode information to the player in playingpage
                var firstItem = podCast[0];
                var firstUrl = firstItem.episodeUrl;
                var firstEpisodeTitle = firstItem.episodeTitle;
                var firstEpisodeDescription = firstItem.Description;


                ViewBag.newImageUrl = imageUrl;

                ViewBag.ListEpisode = podCast;
                ViewBag.choosenEpisodeUrl = firstUrl;
                ViewBag.choosenEpisodeTitle = firstEpisodeTitle;
                ViewBag.choosenEpisodeDescription = firstEpisodeDescription;
                if (admittedEpisode != "")
                {
                    ViewBag.choosenEpisodeUrl = admittedEpisode;
                    ViewBag.choosenEpisodeTitle = episodeName;
                    ViewBag.choosenEpisodeDescription = newEpisodeDescription;
                }


                return View(podCast);
            }
        }
    }





