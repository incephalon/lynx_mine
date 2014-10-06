using System.Web.Mvc;
using DataAccess;

namespace lynx_mine.Controllers
{
    public class HomeController : Controller
    {
        private DataContext _dbContext;
        private DataContext DbContext
        {
            get { return _dbContext ?? (_dbContext = new DataContext()); }
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}