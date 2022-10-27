using EquipmentManager.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManager.Infrastructure.Configurator
{
    internal class EquipmentPositionHistoryConfigurator : IEntityTypeConfiguration<EquipmentPositionHistory>
    {

        public void Configure(EntityTypeBuilder<EquipmentPositionHistory> builder)
        {

            builder
                .ToTable("Equipment_Position_History");
            builder
                .HasKey(x => x.Id)
                .HasName("Id_EquipmentPositionHistory");

            builder.HasOne(x => x.Equipment)
                .WithMany(x => x.EquipmentPositionHistories);

            builder.Ignore(x => x.Notifications);
            builder.Ignore(x => x.IsValid);
        }
    }
}
