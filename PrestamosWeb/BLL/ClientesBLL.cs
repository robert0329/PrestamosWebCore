using Microsoft.EntityFrameworkCore;
using PrestamosWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamosWeb.BLL
{
    public class ClientesBLL
    {
        public static bool Guardar(Clientes nuevo)
        {
            using (var conexion = new PrestamosDb())
            {
                try
                {
                    conexion.Clientes.Add(nuevo);
                    if (conexion.SaveChanges() > 0)
                    {
                        return true;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }
        public static bool Modificar(Clientes nuevo)
        {
            using (var conexion = new PrestamosDb())
            {
                try
                {
                    conexion.Entry(nuevo).State = EntityState.Modified;
                    if (conexion.SaveChanges() > 0)
                        return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return false;
        }
        public static Clientes Buscar(int? Id)
        {
            Clientes nuevo = null;
            using (var conexion = new PrestamosDb())
            {
                try
                {
                    nuevo = conexion.Clientes.Find(Id);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return nuevo;
        }
        public static bool Eliminar(Clientes nuevo)
        {
            using (var conexion = new PrestamosDb())
            {
                try
                {
                    conexion.Entry(nuevo).State = EntityState.Deleted;
                    if (conexion.SaveChanges() > 0)
                    {
                        return true;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }
        public static bool Eliminar(int? Id)
        {
            try
            {
                return Eliminar(Buscar(Id));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Clientes> Listar()
        {
            List<Clientes> listado = null;
            using (var conexion = new PrestamosDb())
            {
                try
                {
                    listado = conexion.Clientes.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }
        public static List<Clientes> ListarId(int Id)
        {
            List<Clientes> list = new List<Clientes>();
            using (var db = new PrestamosDb())
            {
                try
                {
                    list = db.Clientes.Where(p => p.ClienteId == Id).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return list;
        }
        public static int Identity()
        {
            int identity = 0;
            string con =
            @"Data Source=ROBERT\WEBSERVICE;Initial Catalog=WebService;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection conexion = new SqlConnection(con))
            {
                try
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("SELECT IDENT_CURRENT('Clientes')", conexion);
                    identity = Convert.ToInt32(comando.ExecuteScalar());
                    conexion.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return identity;
        }
    }
}
