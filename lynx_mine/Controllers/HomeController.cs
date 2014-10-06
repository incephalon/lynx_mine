using System.Web.Mvc;
using DataAccess;
using lynx_mine.Model;
using DataAccess.Model;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace lynx_mine.Controllers
{
    public class HomeController : Controller
    {
        private DataContext _dbContext;
        private DataContext DbContext
        {
            get { return _dbContext ?? (_dbContext = new DataContext()); }
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Manage(ArticleModel model)
        {
            Article article = null;
            if (model.Id.HasValue)
                article = DbContext.Articles
                    .Include(x => x.Tags)
                    .Where(x => x.Id == model.Id)
                    .FirstOrDefault();
            else
                article = new Article { };
            if (article == null)
                throw new HttpException();
            article.Url = model.Url;
            article.Note = model.Note;
            if (!string.IsNullOrWhiteSpace(model.Tags))
            {
                var tags = model.Tags.Split(' ').Select(x => x.Trim());
                foreach (var t in article.Tags)
                    if (!tags.Contains(t.Name))
                        article.Tags.Remove(t);
                       
                foreach(var t in tags)
                    if (!article.Tags.Any(x => x.Name == t))
                    {
                        var tag = DbContext.Tags.FirstOrDefault(x => x.Name == t);
                        if (tag != null)
                            article.Tags.Add(tag);
                        else
                            article.Tags.Add(new Tag { Name = t });
                    }
            }
            return View("Index");
        }
    }
}