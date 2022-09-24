﻿using EquipmentManager.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManager.Infrastructure.Configurator
{
    public class EquipmentModelConfigurator : IEntityTypeConfiguration<EquipmentModel>
    {

        public void Configure(EntityTypeBuilder<EquipmentModel> builder)
        {

            builder
                .ToTable("Equipment_Model");
            builder
                .HasKey(x => x.Id);
            builder
                .Property(p => p.Id)
                .HasColumnName("Id_Equipment_Model");
            builder
                .Property(p => p.Name).HasColumnName("Name_Equipment_Model")
                .HasColumnType("varchar(50)").IsRequired();

            builder.Ignore(x => x.Notifications);
            builder.Ignore(x => x.IsValid);
        }
    }
}
