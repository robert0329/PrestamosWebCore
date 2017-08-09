using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PrestamosWeb.Models;

namespace PrestamosWeb.Migrations
{
    [DbContext(typeof(PrestamosDb))]
    [Migration("20170808133803_Primera")]
    partial class Primera
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
