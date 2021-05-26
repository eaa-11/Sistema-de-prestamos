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
    public class MovimientoPrestamoDAO
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);
        
        public List<MovimientoPrestamo> GetListMovimientos(string filter)
        {
            List<MovimientoPrestamo> listMovimientoPrestamo = new List<MovimientoPrestamo>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_filtrarMovimientosPrestamos", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                cmd.Parameters.AddWithValue("@filter", filter);
                SqlDataReader result = cmd.ExecuteReader();

                while (result.Read())
                {
                    listMovimientoPrestamo.Add(new MovimientoPrestamo
                    {
                        Id = result.GetInt32(0),
                        Monto_pendiente = result.GetDecimal(1),
                        Prestamo = new PrestamoDAO().Search(result.GetInt32(2))
                    });
                }
                connection.Close();
                result.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
            return listMovimientoPrestamo;
        }
    }
}
