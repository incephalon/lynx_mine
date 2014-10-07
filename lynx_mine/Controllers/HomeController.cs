using System.Web.Mvc;
using DataAccess;
using lynx_mine.Model;
using DataAccess.Model;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System;

namespace lynx_mine.Controllers
{
    public class HomeController : Controller
    {
        private Lazy<DataContext> _dbContext = new Lazy<DataContext>(() => new DataContext());

		[HttpGet]
		public ActionResult Index(int? id)
		{
			if(id == null)
				return View(new ArticleModel());
            Article article = _dbContext.Value.Articles.Include(x => x.Tags).FirstOrDefault(x => x.Id == id);
			if(article != null)
			{
				ArticleModel am = new ArticleModel { 
					Id = article.Id,
					Note = article.Note,
					Url = article.Url,
					Tags = article.Tags.Select(x => x.Name).ToList()
				};
				return View(am);
			}
			return View(new ArticleModel());
		}

		[HttpGet]
		public ActionResult Manage(int? id)
		{
			if (id == null)
				return PartialView(new ArticleModel());
			Article article = _dbContext.Value.Articles.Include(x => x.Tags).FirstOrDefault(x => x.Id == id);
			if (article != null)
			{
				ArticleModel am = new ArticleModel
				{
					Id = article.Id,
					Note = article.Note,
					Url = article.Url,
					Tags = article.Tags.Select(x => x.Name).ToList()
				};
				return PartialView(am);
			}
			return PartialView(new ArticleModel());
		}

        [HttpPost]
		[ValidateInput(false)]
        public ActionResult Manage(ArticleModel model)
        {
            Article article = null;
            if (model.Id.HasValue)
                article = _dbContext.Value.Articles
                    .Include(x => x.Tags)
                    .Where(x => x.Id == model.Id)
                    .FirstOrDefault();
            else
                article = new Article { };
				
            if (article == null)
                throw new HttpException();
            article.Url = model.Url;
            article.Note = model.Note;
			if (model.Tags != null && model.Tags.Count > 0)
            {
                foreach (var t in article.Tags.ToList())
					if (!model.Tags.Contains(t.Name))
                        article.Tags.Remove(t);

				foreach (var t in model.Tags)
                    if (!article.Tags.Any(x => x.Name == t))
                    {
                        var tag = _dbContext.Value.Tags.FirstOrDefault(x => x.Name == t);
                        if (tag != null)
                            article.Tags.Add(tag);
                        else
                            article.Tags.Add(new Tag { Name = t });
                    }
            }
			if (!model.Id.HasValue)
                _dbContext.Value.Articles.Add(article);
            _dbContext.Value.SaveChanges();
			model.Id = article.Id;
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