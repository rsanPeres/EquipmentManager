﻿// <auto-generated />
using System;
using EquipmentManager.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EquipmentManager.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230105190907_columnType")]
    partial class columnType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EquipmentManager.Domain.Entities.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id_Equipment");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EquipmentModelId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentModelId");

                    b.ToTable("Equipment", (string)null);
                });

            modelBuilder.Entity("EquipmentManager.Domain.Entities.EquipmentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id_EquipmentModel");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Equipment_Model", (string)null);
                });

            modelBuilder.Entity("EquipmentManager.Domain.Entities.EquipmentModelStateHourlyEarning", b =>
                {
                    b.Property<int>("EquipmentStateId")
                        .HasColumnType("integer");

                    b.Property<int>("EquipmentModelId")
                        .HasColumnType("integer");

                    b.Property<decimal>("EarnedValueByHourState")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("EquipmentStateId", "EquipmentModelId")
                        .HasName("Id_EquipmentModelStateHourlyEarning");

                    b.HasIndex("EquipmentModelId");

                    b.ToTable("Equipment_Model_State_Hourly_Earning", (string)null);
                });

            modelBuilder.Entity("EquipmentManager.Domain.Entities.EquipmentPositionHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateRegisteredPosition")
                        .HasColumnType("datetime2");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Length")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("Id_EquipmentPositionHistory");

                    b.HasIndex("EquipmentId");

                    b.ToTable("Equipment_Position_History", (string)null);
                });

            modelBuilder.Entity("EquipmentManager.Domain.Entities.EquipmentState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id_EquipmentState");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EquipmentColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Equipment_State", (string)null);
                });

            modelBuilder.Entity("EquipmentManager.Domain.Entities.EquipmentStateHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EquipmentId")
                        .HasColumnType("integer");

                    b.Property<int>("EquipmentStateId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ReportedStatusStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id")
                        .HasName("Id_EquipmentStateHistory");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("EquipmentStateId");

                    b.ToTable("Equipment_State_History", (string)null);
                });

            modelBuilder.Entity("EquipmentManager.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Integer")
                        .HasColumnName("Id_User");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("EquipmentManager.Domain.Entities.Equipment", b =>
                {
                    b.HasOne("EquipmentManager.Domain.Entities.EquipmentModel", "EquipmentModel")
                        .WithMany("Equipments")
                        .HasForeignKey("EquipmentModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EquipmentModel");
                });

            modelBuilder.Entity("EquipmentManager.Domain.Entities.EquipmentModelStateHourlyEarning", b =>
                {
                    b.HasOne("EquipmentManager.Domain.Entities.EquipmentModel", "EquipmentModel")
                        .WithMany("EquipmentsStateHourlyEarning")
                        .HasForeignKey("EquipmentModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EquipmentManager.Domain.Entities.EquipmentState", "EquipmentState")
                        .WithMany("EquipmentsStateHourlyEarning")
                        .HasForeignKey("EquipmentStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EquipmentModel");

                    b.Navigation("EquipmentState");
                });

            modelBuilder.Entity("EquipmentManager.Domain.Entities.EquipmentPositionHistory", b =>
                {
                    b.HasOne("EquipmentManager.Domain.Entities.Equipment", "Equipment")
                        .WithMany("EquipmentPositionsHistory")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("EquipmentManager.Domain.Entities.EquipmentStateHistory", b =>
                {
                    b.HasOne("EquipmentManager.Domain.Entities.Equipment", "Equipment")
                        .WithMany("EquipmentStatesHistory")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EquipmentManager.Domain.Entities.EquipmentState", "EquipmentState")
                        .WithMany("EquipmentStatesHistory")
                        .HasForeignKey("EquipmentStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");

                    b.Navigation("EquipmentState");
                });

            modelBuilder.Entity("EquipmentManager.Domain.Entities.Equipment", b =>
                {
                    b.Navigation("EquipmentPositionsHistory");

                    b.Navigation("EquipmentStatesHistory");
                });

            modelBuilder.Entity("EquipmentManager.Domain.Entities.EquipmentModel", b =>
                {
                    b.Navigation("Equipments");

                    b.Navigation("EquipmentsStateHourlyEarning");
                });

            modelBuilder.Entity("EquipmentManager.Domain.Entities.EquipmentState", b =>
                {
                    b.Navigation("EquipmentStatesHistory");

                    b.Navigation("EquipmentsStateHourlyEarning");
                });
#pragma warning restore 612, 618
        }
    }
}
