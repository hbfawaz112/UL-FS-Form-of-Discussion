using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Asp.net_Project.Models
{
    public class ConfigDB : DbContext
    {

        public ConfigDB() { }

        public System.Data.Entity.DbSet<Asp.net_Project.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<Asp.net_Project.Models.Question> Questions { get; set; }

        public System.Data.Entity.DbSet<Asp.net_Project.Models.Answer> Answers { get; set; }

        public System.Data.Entity.DbSet<Asp.net_Project.Models.Admin> Admins { get; set; }

    }
}