using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Entities.Enuns;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EquipmentManager.Infrastructure.Configurator
{
    public class UserConfigurator : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder
                .ToTable("User");
            builder
                .HasKey(x => x.Id);
            builder
                .Property(p => p.Id)
                .HasColumnName("Id_User");
            builder
                .Property(p => p.Cpf).HasMaxLength(11).IsRequired();
            builder
                .Property(p => p.Password).HasColumnName("Password")
                .HasColumnType("varchar(100)").IsRequired();
            builder
                .Property(p => p.UserName).HasColumnName("User_Name")
                .HasColumnType("varchar(50)").IsRequired();
            builder
                .Property(p => p.Role).HasConversion<EnumToStringConverter<RoleNames>>();
            builder
                .Property(p => p.RoleId).IsRequired();

            builder.Ignore(x => x.Notifications);
            builder.Ignore(x => x.IsValid);
        }
    }
}
