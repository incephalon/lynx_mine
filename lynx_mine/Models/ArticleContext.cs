using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace lynx_mine.Models
{
    public class ArticleContext : DbContext
    {
        //add connection
        public ArticleContext() : base("AzureConnection")
        {

        }


        public DbSet<Article> Articles { get; set; }

    }
}