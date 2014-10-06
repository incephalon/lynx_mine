using DataAccess.Configurations;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class DataContext:DbContext
	{
		public DbSet<Article> Articles { get; set; }
		public DbSet<Tag> Tags { get; set; }

		public DataContext()
			: base("DataContext")
		{

		}

		private static void AddControlConfigurations(ConfigurationRegistrar configurations)
		{
			configurations.Add(new ArticleConfiguration());
			configurations.Add(new TagConfiguration());
		}
	}
}
