using System.Web.Mvc;
using DataAccess;
using lynx_mine.Model;
using DataAccess.Model;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Collections.Generic;
using System.Web.Http;
using System;

namespace lynx_mine.Controllers
{
    public class SearchController : Controller
    {
        private Lazy<DataContext> _dbContext = new Lazy<DataContext>(() => new DataContext());

		public ActionResult Index([FromUri]string term)
		{
			var result = new List<ArticleModel>();
			var tag = _dbContext.Value.Tags
                .Include("Articles.Tags")
                .FirstOrDefault(x => x.Name == term);
            return View(tag == null
                ? new List<ArticleModel>()
                : tag.Articles.Select(x => new ArticleModel {
                    Id = x.Id,
                    Note = x.Note,
                    Url = x.Url,
                    Tags = x.Tags.Select(y => y.Name).ToList()
                }).ToList());
		}
    }
}