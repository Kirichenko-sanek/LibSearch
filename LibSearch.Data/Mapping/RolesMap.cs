﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LibSearch.Core.Model;

namespace LibSearch.Data.Mapping
{
    class RolesMap : EntityTypeConfiguration<Roles>
    {
        public RolesMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.Role).IsRequired();
            ToTable("Roles");
        }
    }
}
