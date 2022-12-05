using MySql.Data.MySqlClient;
using Noviembrex.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembrex.Core.Entidades
{
    public class Guaymas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public static Guaymas GetById(int id)
        {
            Guaymas guaymas = new Guaymas();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre, apellido, telefono, direccion FROM guaymas WHERE id = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        guaymas.Id = int.Parse(dataReader["id"].ToString());
                        guaymas.Nombre = dataReader["nombre"].ToString();
                        guaymas.Apellido = dataReader["apellido"].ToString();
                        guaymas.Telefono = dataReader["telefono"].ToString();
                        guaymas.Direccion = dataReader["direccion"].ToString();
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return guaymas;
        }


        public static List<Guaymas> GetAll()
        {
            List<Guaymas> guaymass = new List<Guaymas>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre, apellido, telefono, direccion FROM guaymas ORDER BY nombre;";

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Guaymas guaymas = new Guaymas();
                        guaymas.Id = int.Parse(dataReader["id"].ToString());
                        guaymas.Nombre = dataReader["nombre"].ToString();
                        guaymas.Apellido = dataReader["apellido"].ToString();
                        guaymas.Telefono = dataReader["telefono"].ToString();
                        guaymas.Direccion = dataReader["direccion"].ToString();


                        guaymass.Add(guaymas);
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return guaymass;
        }


        public static bool Guardar(int id, string nombre, string apellido, string telefono, string direccion)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();

                    if (id == 0)
                    {
                        cmd.CommandText = "INSERT INTO guaymas (nombre, apellido, telefono, direccion) " +
                            "VALUES (@nombre, @apellido, @telefono, @direccion)";
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@direccion", direccion);
                    }
                    else
                    {
                        cmd.CommandText = "UPDATE guaymas SET nombre = @nombre, apellido = @apellido, telefono = @telefono, direccion = @direccion " +
                            "WHERE id = @id";
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@direccion", direccion);
                    }

                    result = cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


        public bool Editar(int id, string nombre, string apellido, string telefono, string direccion)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();
                    cmd.CommandText = "UPDATE guaymas SET nombre = @nombre, apellido = @apellido, telefono = @telefono, direccion = @direccion  WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@direccion", direccion);

                    result = cmd.ExecuteNonQuery() == 1;

                    /*if(cmd.ExecuteNonQuery() == 1) {
                        result = true;
                    } else {
                        result = false;
                    }*/
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static bool Eliminar(int id)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();
                    cmd.CommandText = "DELETE FROM guaymas WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    result = cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
