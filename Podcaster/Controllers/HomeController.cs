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

            List<ValutaTest> podEpisode = new List<ValutaTest>();

            //Load the XML file in XmlDocument.
            //XmlDocument doc = new XmlDocument();
            //doc.Load(Server.MapPath("http://freecodecamp.libsyn.com/rss"));




            //string uri = "http://freecodecamp.libsyn.com/rss";


            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://www.ecb.int/stats/eurofxref/eurofxref-daily.xml");
            foreach (XmlNode xmlNode in xmlDoc.DocumentElement.ChildNodes[2].ChildNodes[0].ChildNodes)
            {

                podEpisode.Add(new ValutaTest
                {
                    Currency = xmlNode.Attributes["currency"].Value,
                    Rate = xmlNode.Attributes["rate"].Value
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