using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podcaster.Models
{
    public class Podcast 
    {
        public int ID { get; set; }

        public string PodcastTitle { get; set; }

        public string PodcastRss { get; set; }

        public string PodcastImage { get; set; }

    }
}