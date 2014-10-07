using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
	public class Tag : Persistent
	{
		public Tag()
        {
            Articles = new List<Article>();
        }

		public string Name { get; set; }

		public ICollection<Article> Articles { get; set; }
	}
}
