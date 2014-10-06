using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
	public class Article : PersistentModel
	{
        public Article()
        {
            Tags = new List<Tag>();
        }

		public string Url { get; set; }
		public string Note { get; set; }

		public ICollection<Tag> Tags { get; set; }
	}
}
