using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Entidades;
using Entidades.Interface;
using System.Data;

namespace Datos
{
    public class ClienteDAO
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);


        public List<ICliente> GetListCliente(string filter)
        {
            List<ICliente> listCliente = new List<ICliente>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_filtrarClientes", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                cmd.Parameters.AddWithValue("@filter", filter);
                SqlDataReader result = cmd.ExecuteReader();

                while (result.Read())
                {
                    listCliente.Add(new Cliente
                    {
                        Id = result.GetInt32(0),
                        Cedula = result.GetString(1).Trim(),
                        Nombre = result.GetString(2).Trim(),
                        Email = result.GetString(3).Trim(),
                        Direccion = result.GetString(4).Trim(),
                        Telefono = result.GetString(5).Trim()
                    });
                }
                connection.Close();
                result.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
            return listCliente;
        }

        public bool Create(Cliente cliente)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_insertarClientes", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                cmd.Parameters.AddWithValue("@cedula", cliente.Cedula);
                cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@email", cliente.Email);
                cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public bool Edit(Cliente cliente)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_actualizarClientes", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                cmd.Parameters.AddWithValue("@id", cliente.Id);
                cmd.Parameters.AddWithValue("@cedula", cliente.Cedula);
                cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@email", cliente.Email);
                cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
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
                SqlCommand cmd = new SqlCommand("sp_eliminarClientes", connection);
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

        public Cliente GetClient(int id)
        {
            Cliente cliente = null;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_buscarClientes", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader result = cmd.ExecuteReader();

                while (result.Read())
                {
                    cliente = new Cliente
                    {
                        Id = result.GetInt32(0),
                        Cedula = result.GetString(1).Trim(),
                        Nombre = result.GetString(2).Trim(),
                        Email = result.GetString(3).Trim(),
                        Direccion = result.GetString(4).Trim(),
                        Telefono = result.GetString(5).Trim()
                    };
                }
                connection.Close();
                result.Close();
            }
            catch (Exception)
            {
            }
            return cliente;
        }
    }
}
