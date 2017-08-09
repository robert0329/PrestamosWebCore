using Microsoft.EntityFrameworkCore;
using PrestamosWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamosWeb.BLL
{
    public class UsuariosBLL
    {
        public static bool Guardar(Usuarios usuario)
        {
            using (var conexion = new PrestamosDb())
            {
                try
                {
                    conexion.Usuarios.Add(usuario);
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
        public static bool Modificar(Usuarios usuarios)
        {
            using (var conexion = new PrestamosDb())
            {
                try
                {
                    conexion.Entry(usuarios).State = EntityState.Modified;
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
        public static Usuarios Buscar(int? usuarioId)
        {
            Usuarios usuario = null;
            using (var conexion = new PrestamosDb())
            {
                try
                {
                    usuario = conexion.Usuarios.Find(usuarioId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return usuario;
        }
        public static bool Eliminar(Usuarios usuarios)
        {
            using (var conexion = new PrestamosDb())
            {
                try
                {
                    conexion.Entry(usuarios).State = EntityState.Deleted;
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
        public static bool Eliminar(int? usuarioId)
        {
            try
            {
                return Eliminar(Buscar(usuarioId));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Usuarios> Listar()
        {
            List<Usuarios> listado = null;
            using (var conexion = new PrestamosDb())
            {
                try
                {
                    listado = conexion.Usuarios.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }
        public static List<Usuarios> ListarId(int Id)
        {
            List<Usuarios> list = new List<Usuarios>();
            using (var db = new PrestamosDb())
            {
                try
                {
                    list = db.Usuarios.Where(p => p.UsuarioId == Id).ToList();
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
                    SqlCommand comando = new SqlCommand("SELECT IDENT_CURRENT('Usuarios')", conexion);
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
