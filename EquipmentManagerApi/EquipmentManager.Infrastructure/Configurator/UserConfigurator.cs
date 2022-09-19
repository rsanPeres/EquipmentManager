using EquipmentManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            builder.Ignore(x => x.Notifications);
            builder.Ignore(x => x.IsValid);
        }
    }
}
