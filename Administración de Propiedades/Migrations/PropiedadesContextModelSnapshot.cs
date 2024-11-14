﻿// <auto-generated />
using System;
using Administración_de_Propiedades.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Administración_de_Propiedades.Migrations
{
    [DbContext(typeof(PropiedadesContext))]
    partial class PropiedadesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Administración_de_Propiedades.Model.Contrato", b =>
                {
                    b.Property<int>("IdContrato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdContrato"));

                    b.Property<decimal>("Deposito")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdInquilino")
                        .HasColumnType("int");

                    b.Property<int>("IdPropiedad")
                        .HasColumnType("int");

                    b.Property<string>("Terminos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdContrato");

                    b.HasIndex("IdInquilino");

                    b.HasIndex("IdPropiedad");

                    b.ToTable("Contratos");
                });

            modelBuilder.Entity("Administración_de_Propiedades.Model.Inquilino", b =>
                {
                    b.Property<int>("IdInquilino")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInquilino"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPropiedad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdInquilino");

                    b.HasIndex("IdPropiedad");

                    b.ToTable("Inquilinos");
                });

            modelBuilder.Entity("Administración_de_Propiedades.Model.Pago", b =>
                {
                    b.Property<int>("IdPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPago"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdContrato")
                        .HasColumnType("int");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdPago");

                    b.HasIndex("IdContrato");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("Administración_de_Propiedades.Model.Propiedad", b =>
                {
                    b.Property<int>("IdPropiedad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPropiedad"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Disponible")
                        .HasColumnType("bit");

                    b.Property<int>("NumeroHabitaciones")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecioAlquiler")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TipoPropiedad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPropiedad");

                    b.ToTable("Propiedades");
                });

            modelBuilder.Entity("Administración_de_Propiedades.Model.Contrato", b =>
                {
                    b.HasOne("Administración_de_Propiedades.Model.Inquilino", "Inquilino")
                        .WithMany("Contratos")
                        .HasForeignKey("IdInquilino")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Administración_de_Propiedades.Model.Propiedad", "Propiedad")
                        .WithMany("Contratos")
                        .HasForeignKey("IdPropiedad")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Inquilino");

                    b.Navigation("Propiedad");
                });

            modelBuilder.Entity("Administración_de_Propiedades.Model.Inquilino", b =>
                {
                    b.HasOne("Administración_de_Propiedades.Model.Propiedad", "Propiedad")
                        .WithMany("Inquilinos")
                        .HasForeignKey("IdPropiedad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Propiedad");
                });

            modelBuilder.Entity("Administración_de_Propiedades.Model.Pago", b =>
                {
                    b.HasOne("Administración_de_Propiedades.Model.Contrato", "Contrato")
                        .WithMany("Pagos")
                        .HasForeignKey("IdContrato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contrato");
                });

            modelBuilder.Entity("Administración_de_Propiedades.Model.Contrato", b =>
                {
                    b.Navigation("Pagos");
                });

            modelBuilder.Entity("Administración_de_Propiedades.Model.Inquilino", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("Administración_de_Propiedades.Model.Propiedad", b =>
                {
                    b.Navigation("Contratos");

                    b.Navigation("Inquilinos");
                });
#pragma warning restore 612, 618
        }
    }
}
