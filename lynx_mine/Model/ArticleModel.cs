using System.Collections.Generic;
namespace lynx_mine.Model
{
	public class ArticleModel
	{
		public ArticleModel()
		{
			Tags = new List<string>();
		}

		public int? Id { get; set; }
		public string Url { get; set; }
		public string Note { get; set; }
		public string TagsString { get; set; }
		public List<string> Tags { get; set; }
	}
}