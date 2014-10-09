using DataAccess;
using lynx_mine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace lynx_mine.Controllers
{
	public class SearchController : Controller
	{
		private Lazy<DataContext> _dbContext = new Lazy<DataContext>(() => new DataContext());

		public ActionResult Index([FromUri]string term)
		{
			var tags = term.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
			tags.ForEach(x => x.Trim());
			var result = new List<ArticleModel>();
			var tagsWithArticles = _dbContext.Value.Articles
				.Include("Tags")
				.Where(x => x.Tags.Any(s => tags.Any(e => e == s.Name)));

			var model = tagsWithArticles.Select(x => new ArticleModel
			{
				Id = x.Id,
				Note = x.Note,
				Url = x.Url,
				Tags = x.Tags.Select(y => y.Name).ToList()
			}).ToList();

			return PartialView(model);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
				if (_dbContext.IsValueCreated)
					_dbContext.Value.Dispose();
			base.Dispose(disposing);
		}
	}
}