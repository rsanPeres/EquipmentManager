using EquipmentManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            builder
                .Property(x => x.Id).HasColumnType("integer");
            builder.HasOne(x => x.Equipment)
                .WithMany(x => x.EquipmentPositionsHistory);

            builder.Ignore(x => x.Notifications);
            builder.Ignore(x => x.IsValid);
        }
    }
}
