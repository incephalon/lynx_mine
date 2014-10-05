using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Model;
using System.Web.Http;

namespace lynx_mine.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

		DataContext dbContext = new DataContext();

        public ActionResult Index()
        {
            return View();
        }

		public JsonResult Tags([FromUri]string term)
		{
			List<TagModel> tags = dbContext.Tags.Where(x => x.Name.Contains(term)).ToList();
			if (!tags.Exists(x => x.Name == term))
			{
				tags.Add(new TagModel {Name = term });
			}
			return Json(tags,JsonRequestBehavior.AllowGet);
		}
    }
}
