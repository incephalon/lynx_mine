﻿using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
	public class TagConfiguration : EntityTypeConfiguration<TagModel>
	{
		public TagConfiguration()
		{
			HasKey(x => x.Id);
			Property(x => x.Name)
				.HasMaxLength(255)
				.IsRequired();

			HasMany(x => x.Articles)
				.WithMany();

			ToTable("Tags");
		}
	}
}