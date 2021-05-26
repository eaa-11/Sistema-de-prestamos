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
    public class PagoDAO
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);
        public List<Pago> GetListPagos()
        {
            List<Pago> listPago = new List<Pago>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_allPagos", connection);              
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader result = cmd.ExecuteReader();

                while (result.Read())
                {
                    listPago.Add(new Pago
                    {
                        Id = result.GetInt32(0),
                        Fecha = result.GetDateTime(1).Date,
                        Monto_pagado = result.GetDecimal(2),
                        Prestamo = new PrestamoDAO().Search(result.GetInt32(3)),
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
            return listPago;
        }

        public List<Pago> FilterByDate(DateTime fecha_inicio, DateTime fecha_fin)
        {
            List<Pago> listPago = new List<Pago>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_filtrarPagos", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                cmd.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
                cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
                SqlDataReader result = cmd.ExecuteReader();

                while (result.Read())
                {
                    listPago.Add(new Pago
                    {
                        Id = result.GetInt32(0),
                        Fecha = result.GetDateTime(1).Date,
                        Monto_pagado = result.GetDecimal(2),
                        Prestamo = new PrestamoDAO().Search(result.GetInt32(3)),
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
            return listPago;
        }

        public bool Create(Pago Pago)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_insertarPagos", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                cmd.Parameters.AddWithValue("@fecha", Pago.Fecha);
                cmd.Parameters.AddWithValue("@monto_pagado", Pago.Monto_pagado);
                cmd.Parameters.AddWithValue("@prestamo_id", Pago.Prestamo.Id);
                cmd.Parameters.AddWithValue("@cliente_id", Pago.Cliente.Id);
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e.Message);
                return false;
            }
        }

        public bool Edit(Pago Pago)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_actualizarPagos", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                cmd.Parameters.AddWithValue("@id", Pago.Id);
                cmd.Parameters.AddWithValue("@fecha", Pago.Fecha);
                cmd.Parameters.AddWithValue("@monto_pagado", Pago.Monto_pagado);
                cmd.Parameters.AddWithValue("@prestamo_id", Pago.Prestamo.Id);
                cmd.Parameters.AddWithValue("@cliente_id", Pago.Cliente.Id);
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
                SqlCommand cmd = new SqlCommand("sp_eliminarPagos", connection);
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

        public Pago Search(int id)
        {
            Pago Pago = null;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_buscarPagos", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader result = cmd.ExecuteReader();

                while (result.Read())
                {
                    Pago = new Pago
                    {
                        Id = result.GetInt32(0),
                        Fecha = result.GetDateTime(1).Date,
                        Monto_pagado = result.GetDecimal(2),
                        Prestamo = new PrestamoDAO().Search(result.GetInt32(3)),
                        Cliente = new ClienteDAO().GetClient(result.GetInt32(4))
                    };
                }
                connection.Close();
                result.Close();
            }
            catch (Exception)
            {
            }
            return Pago;
        }
    }
}
