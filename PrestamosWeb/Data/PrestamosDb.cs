using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrestamosWeb.Models;

namespace PrestamosWeb.Models
{
    public class PrestamosDb : DbContext
    {
        public PrestamosDb (): base(){}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ROBERT\\WEBSERVICE;Initial Catalog=WebService;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public DbSet<PrestamosWeb.Models.Clientes> Clientes { get; set; }
        public DbSet<PrestamosWeb.Models.Usuarios> Usuarios { get; set; }
    }
}
