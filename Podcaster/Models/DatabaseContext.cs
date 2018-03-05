using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Podcaster.Models
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext() : base("name=DbConnection")
        {
        }

        public System.Data.Entity.DbSet<Podcaster.Models.Podcast> Podcasts { get; set; }
    }
}