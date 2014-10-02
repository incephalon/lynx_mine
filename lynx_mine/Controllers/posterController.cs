using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using lynx_mine.Models;

namespace lynx_mine.Controllers
{
    public class posterController : ApiController
    {
        public void Post(Article newArticle)
        {
            using (var db = new ArticleContext())
            {
                db.Articles.Add(newArticle);
                db.SaveChanges();
            }

        }


        public void Get(string searchTerm)
        {

            using (var db = new ArticleContext())
            {

                //search through the tags on each article, if it contains the search term, add it to list that will be returned


            }

        }
    }
}
