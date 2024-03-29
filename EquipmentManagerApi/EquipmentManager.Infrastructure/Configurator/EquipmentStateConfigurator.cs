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
    internal class EquipmentStateConfigurator : IEntityTypeConfiguration<EquipmentState>
    {

        public void Configure(EntityTypeBuilder<EquipmentState> builder)
        {

            builder
                 .ToTable("Equipment_State");
            builder
                .HasKey(x => x.Id);
            builder
                .Property(x => x.Id).HasColumnType("integer");

            builder
                .Property(p => p.Id)
                .HasColumnName("Id_EquipmentState");
            builder
                .Property(p => p.StateName)
                .HasColumnType("varchar(50)").IsRequired();

            builder.Ignore(x => x.Notifications);
            builder.Ignore(x => x.IsValid);
        }
    }
}
