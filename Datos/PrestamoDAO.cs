using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Entidades;
using System.Data;

namespace Datos
{
    public class PrestamoDAO
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);
        public List<Prestamo> GetListPrestamos(string filter)
        {
            List<Prestamo> listPrestamo = new List<Prestamo>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_filtrarPrestamos", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                cmd.Parameters.AddWithValue("@filter", filter);
                SqlDataReader result = cmd.ExecuteReader();

                while (result.Read())
                {
                    listPrestamo.Add(new Prestamo
                    {
                        Id = result.GetInt32(0),
                        Fecha = result.GetDateTime(1).Date,
                        Monto_prestamo = result.GetInt32(2),
                        Cuotas = result.GetInt32(3),
                        Cliente = new ClienteDAO().GetClient(result.GetInt32(4))
                    });
                }
                connection.Close();
                result.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
            return listPrestamo;
        }

        public bool Create(Prestamo Prestamo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_insertarPrestamos", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                cmd.Parameters.AddWithValue("@fecha", Prestamo.Fecha);
                cmd.Parameters.AddWithValue("@monto_prestado", Prestamo.Monto_prestamo);
                cmd.Parameters.AddWithValue("@cuotas", Prestamo.Cuotas);
                cmd.Parameters.AddWithValue("@cliente_id", Prestamo.Cliente.Id);
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Prestamo Prestamo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_actualizarPrestamos", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                cmd.Parameters.AddWithValue("@id", Prestamo.Id);
                cmd.Parameters.AddWithValue("@fecha", Prestamo.Fecha);
                cmd.Parameters.AddWithValue("@monto_prestado", Prestamo.Monto_prestamo);
                cmd.Parameters.AddWithValue("@cuotas", Prestamo.Cuotas);
                cmd.Parameters.AddWithValue("@cliente_id", Prestamo.Cliente.Id);
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_eliminarPrestamos", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Prestamo Search(int id)
        {
            Prestamo Prestamo = null;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_buscarPrestamos", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader result = cmd.ExecuteReader();

                while (result.Read())
                {
                    Prestamo = new Prestamo
                    {
                        Id = result.GetInt32(0),
                        Fecha = result.GetDateTime(1).Date,
                        Monto_prestamo = result.GetInt32(2),
                        Cuotas = result.GetInt32(3),
                        Cliente = new ClienteDAO().GetClient(result.GetInt32(4))
                    };
                }
                connection.Close();
                result.Close();
            }
            catch (Exception)
            {
            }
            return Prestamo;
        }
    }
}
