using System.Web.Mvc;
using DataAccess;
using lynx_mine.Model;
using DataAccess.Model;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Collections.Generic;
using System.Web.Http;

namespace lynx_mine.Controllers
{
    public class SearchController : Controller
    {

		private DataContext _dbContext;
		private DataContext DbContext
		{
			get { return _dbContext ?? (_dbContext = new DataContext()); }
		}

		public ActionResult Index([FromUri]string term)
		{
			var result = new List<ArticleModel>();
			var Tag = DbContext.Tags.Include("Articles.Tags").FirstOrDefault(x => x.Name == term);
			if (Tag != null)
				result.AddRange(
					Tag.Articles.Select(x => new ArticleModel { 
							Id = x.Id,
							Note = x.Note,
							Url = x.Url,
							Tags = x.Tags.Select(y => y.Name).ToList()
					})
				);
			return View(result);
		}
    }
}