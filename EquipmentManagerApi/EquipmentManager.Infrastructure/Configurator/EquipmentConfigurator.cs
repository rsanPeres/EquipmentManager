using EquipmentManager.Domain.Entities;
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
            builder.Property(x => x.Id).HasColumnType("integer");
            builder
                .Property(p => p.Id)
                .HasColumnName("Id_Equipment");
            builder
                .Property(p => p.Name)
                .HasColumnType("varchar(50)").IsRequired();
             
            builder.HasOne(x => x.EquipmentModel)
                .WithMany(x => x.Equipments);

            builder.Ignore(x => x.Notifications);
            builder.Ignore(x => x.IsValid);
        }
    }
}
