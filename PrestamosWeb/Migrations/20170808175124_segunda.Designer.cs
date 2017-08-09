using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PrestamosWeb.Models;

namespace PrestamosWeb.Migrations
{
    [DbContext(typeof(PrestamosDb))]
    [Migration("20170808175124_segunda")]
    partial class segunda
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PrestamosWeb.Models.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cedula")
                        .IsRequired();

                    b.Property<string>("Ciudad")
                        .IsRequired();

                    b.Property<string>("Direccion")
                        .IsRequired();

                    b.Property<DateTime>("FechaNac");

                    b.Property<string>("Nombres")
                        .IsRequired();

                    b.Property<string>("Telefono")
                        .IsRequired();

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("PrestamosWeb.Models.Usuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apellido")
                        .IsRequired();

                    b.Property<string>("Contraseña")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Nombre")
                        .IsRequired();

                    b.Property<string>("NombreUsuario")
                        .IsRequired();

                    b.Property<int>("Tipo");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });
        }
    }
}
