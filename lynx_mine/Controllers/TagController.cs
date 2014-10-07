using DataAccess;
using DataAccess.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace lynx_mine.Controllers
{
    public class TagController: Controller
    {
        private DataContext _dbContext;
        private DataContext DbContext 
        {
            get { return _dbContext ?? (_dbContext = new DataContext()); }
        }

        public JsonResult Index([FromUri]string term)
        {
			List<string> tags = DbContext.Tags.Where(x => x.Name.Contains(term)).Select(n => n.Name).ToList();
            if (!tags.Exists(x => x == term))
            {
                tags.Add(term);
            }
            return Json(tags, JsonRequestBehavior.AllowGet);
        }
    }
}