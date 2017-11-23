using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podcaster.Models
{
    public class PodcastEpisodeModel
    {
        private string EpisodeTitle;
        private string EpisodeUrl;
        private String publicationDate;
        private string description;
        //private Boolean viewStatus;



        public string episodeTitle
        {
            get
            {
                return EpisodeTitle;
            }

            set
            {
                EpisodeTitle = value;
            }
        }
        public string episodeUrl
        {
            get
            {
                return EpisodeUrl;
            }

            set
            {
                EpisodeUrl = value;
            }
        }

        public string PublicationDate
        {
            get
            {
                return publicationDate;
            }

            set
            {
                publicationDate = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

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