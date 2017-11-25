using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podcaster.Models
{
    public class PodcastEpisodeModel
    {

        public string PodcastName {get; set;}

        public string episodeTitle { get; set; }

        public string episodeUrl { get; set; }

        public string PublicationDate { get; set; }

        public string Description { get; set; }


        //public bool ViewStatus
        //{
        //    get
        //    {
        //        return viewStatus;
        //    }

        //    set
        //    {
        //        viewStatus = value;
        //    }
        //}
    }

}