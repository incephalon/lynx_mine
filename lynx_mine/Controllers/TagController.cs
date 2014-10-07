using DataAccess;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace lynx_mine.Controllers
{
    public class TagController: Controller
    {
        private Lazy<DataContext> _dbContext = new Lazy<DataContext>(() => new DataContext());

        public JsonResult Index([FromUri]string term)
        {
			List<string> tags = _dbContext.Value.Tags.Where(x => x.Name.Contains(term)).Select(n => n.Name).ToList();
            if (!tags.Exists(x => x == term))
            {
                tags.Add(term);
            }
            return Json(tags, JsonRequestBehavior.AllowGet);
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