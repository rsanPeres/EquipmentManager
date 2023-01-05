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
    internal class EquipmentStateHistoryConfigurator : IEntityTypeConfiguration<EquipmentStateHistory>
    {

        public void Configure(EntityTypeBuilder<EquipmentStateHistory> builder)
        {
            builder
                .ToTable("Equipment_State_History");
            builder
                .HasKey(x => x.Id)
                .HasName("Id_EquipmentStateHistory");
            builder
                .Property(x => x.Id).HasColumnType("integer");
            builder.HasOne(x => x.Equipment)
                .WithMany(x => x.EquipmentStatesHistory);

            builder.HasOne(x => x.EquipmentState)
                .WithMany(x => x.EquipmentStatesHistory);
            builder.Ignore(x => x.Notifications);
            builder.Ignore(x => x.IsValid);
        }
    }
}
