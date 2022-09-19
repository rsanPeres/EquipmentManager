﻿using EquipmentManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EquipmentManager.Infrastructure.Configurator
{
    public class EquipmentConfigurator : IEntityTypeConfiguration<Equipment>
    {

        public void Configure(EntityTypeBuilder<Equipment> builder)
        {

            builder
                .ToTable("Equipment");
            builder
                .HasKey(x => x.Id);
            builder
                .Property(p => p.Id)
                .HasColumnName("Id_Equipment");
            builder
                .Property(p => p.Name).HasColumnName("Name_Equipment")
                .HasColumnType("varchar(50)").IsRequired();

            builder.HasOne(x => x.EquipmentModel)
                .WithMany(x => x.Equipments)
                .HasForeignKey(x => x.EquipmentModelId);

            builder.Ignore(x => x.Notifications);
            builder.Ignore(x => x.IsValid);
        }
    }
}
