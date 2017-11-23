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

            List<PodcastEpisodeModel> podEpisode = new List<PodcastEpisodeModel>();

            //fungerar
            //string uri = "http://freecodecamp.libsyn.com/rss";


            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load("http://www.ecb.int/stats/eurofxref/eurofxref-daily.xml");
            //foreach (XmlNode xmlNode in xmlDoc.DocumentElement.ChildNodes[2].ChildNodes[0].ChildNodes)
            //{

            //    podEpisode.Add(new ValutaTest
            //    {
            //        Currency = xmlNode.Attributes["currency"].Value,
            //        Rate = xmlNode.Attributes["rate"].Value
            //    });

            //}
            //slut på den fungerande

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://deadlysiriussxm.libsyn.com/rss");
            //foreach (XmlNode xmlNode in xmlDoc.DocumentElement.SelectNodes("channel/item"))
            //{
            //    //var mainTitle = xmlNode.SelectSingleNode("title");
            //    podEpisode.Add(new PodcastEpisodeModel
            //    {
            //        //Description = xmlNode.Attributes["channel/title"].Value
            //        //Description = xmlDoc.InnerXml
            //      //Description = xmlNode.Attributes["description"].Value


            //});
            foreach (System.Xml.XmlNode temp in xmlDoc.DocumentElement.SelectNodes("channel"))
            {
                var mainTitle = temp.SelectSingleNode("title");
                var main = mainTitle.InnerText;

                podEpisode.Add(new PodcastEpisodeModel
                {
                    //Description = xmlNode.Attributes["channel/title"].Value
                    //Description = xmlDoc.InnerXml
                    //Description = xmlNode.Attributes["description"].Value
                    Description = main
                  
                });


            }

            foreach (System.Xml.XmlNode temp in xmlDoc.DocumentElement.SelectNodes("channel/item"))
            {
                var mainTitle = temp.SelectSingleNode("title");
                var main = mainTitle.InnerText;

                var mainPub = temp.SelectSingleNode("pubDate");
                var PubDt = mainTitle.InnerText;
                podEpisode.Add(new PodcastEpisodeModel
                {
                    //Description = xmlNode.Attributes["channel/title"].Value
                    //Description = xmlDoc.InnerXml
                    //Description = xmlNode.Attributes["description"].Value

                    episodeTitle = main,
                    PublicationDate = PubDt
                    
                });


            }

            return View(podEpisode);



            //fungerar lokalt
            //List<CustomerModel> customers = new List<CustomerModel>();

            ////Load the XML file in XmlDocument.
            //XmlDocument doc = new XmlDocument();
            //doc.Load(Server.MapPath("~/Customers.xml"));

            ////Loop through the selected Nodes.
            //foreach (XmlNode node in doc.SelectNodes("/Customers/Customer"))
            //{
            //    //Fetch the Node values and assign it to Model.
            //    customers.Add(new CustomerModel
            //    {
            //        CustomerId = int.Parse(node["Id"].InnerText),
            //        Name = node["Name"].InnerText,
            //        Country = node["Country"].InnerText
            //    });
            //}

            //return View(customers);

            //originalet
            //return View();
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

            return View();
        }
    }
}