using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
	public class TagModel : PersistentModel
	{
		public string Name { get; set; }

		public virtual ICollection<ArticleModel> Articles { get; set; }
	}
}
