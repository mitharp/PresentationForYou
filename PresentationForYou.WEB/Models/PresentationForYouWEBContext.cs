﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PresentationForYou.WEB.Models
{
    public class PresentationForYouWEBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PresentationForYouWEBContext() : base("name=PresentationForYouWEBContext")
        {
        }

        public System.Data.Entity.DbSet<PresentationForYou.WEB.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<PresentationForYou.WEB.Models.Auditory> Auditories { get; set; }

        public System.Data.Entity.DbSet<PresentationForYou.WEB.Models.Board> Boards { get; set; }

        public System.Data.Entity.DbSet<PresentationForYou.WEB.Models.Projector> Projectors { get; set; }
    }
}
