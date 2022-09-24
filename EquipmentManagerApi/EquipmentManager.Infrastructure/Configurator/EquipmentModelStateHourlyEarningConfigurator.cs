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
    internal class EquipmentModelStateHourlyEarningConfigurator : IEntityTypeConfiguration<EquipmentModelStateHourlyEarning>
    {

        public void Configure(EntityTypeBuilder<EquipmentModelStateHourlyEarning> builder)
        {

            builder
                .ToTable("Equipment_Model_State_Hourly_Earning");
            builder
                .HasKey(x => new {x.EquipmentStateId, x.EquipmentModelId })
                .HasName("Id_EquipmentModelStateHourlyEarning");

            builder.HasOne(x => x.EquipmentModel)
                .WithMany(x => x.EquipmentsStateHourlyEarning)
                .HasForeignKey(x => x.EquipmentModelId);

            builder.HasOne(x => x.EquipmentState)
                .WithMany(x => x.EquipmentsStateHourlyEarning)
                .HasForeignKey(x => x.EquipmentStateId);

            builder.Ignore(x => x.Notifications);
            builder.Ignore(x => x.IsValid);
        }
    }
}
