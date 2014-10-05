using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
	public class ArticleConfiguration : EntityTypeConfiguration<ArticleModel>
	{
		public ArticleConfiguration()
		{
			HasKey(x => x.Id);
			Property(x => x.Url)
				.HasMaxLength(255)
				.IsRequired();
			Property(x => x.Note)
				.IsOptional();

			ToTable("Articles");
		}
	}
}
