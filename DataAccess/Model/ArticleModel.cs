using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
	public class ArticleModel : PersistentModel
	{
		public string Url { get; set; }
		public string Note { get; set; }

		public virtual ICollection<TagModel> Tags { get; set; }
	}
}
