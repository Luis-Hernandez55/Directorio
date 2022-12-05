﻿using MySql.Data.MySqlClient;
using Noviembrex.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembrex.Core.Entidades
{
    public class Nogales
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public static Nogales GetById(int id)
        {
            Nogales nogales = new Nogales();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre, apellido, telefono, direccion FROM nogales WHERE id = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        nogales.Id = int.Parse(dataReader["id"].ToString());
                        nogales.Nombre = dataReader["nombre"].ToString();
                        nogales.Apellido = dataReader["apellido"].ToString();
                        nogales.Telefono = dataReader["telefono"].ToString();
                        nogales.Direccion = dataReader["direccion"].ToString();
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return nogales;
        }


        public static List<Nogales> GetAll()
        {
            List<Nogales> nogaless = new List<Nogales>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre, apellido, telefono, direccion FROM nogales ORDER BY nombre;";

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Nogales nogales = new Nogales();
                        nogales.Id = int.Parse(dataReader["id"].ToString());
                        nogales.Nombre = dataReader["nombre"].ToString();
                        nogales.Apellido = dataReader["apellido"].ToString();
                        nogales.Telefono = dataReader["telefono"].ToString();
                        nogales.Direccion = dataReader["direccion"].ToString();


                        nogaless.Add(nogales);
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return nogaless;
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
                        cmd.CommandText = "INSERT INTO nogales (nombre, apellido, telefono, direccion) " +
                            "VALUES (@nombre, @apellido, @telefono, @direccion)";
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@direccion", direccion);
                    }
                    else
                    {
                        cmd.CommandText = "UPDATE nogales SET nombre = @nombre, apellido = @apellido, telefono = @telefono, direccion = @direccion " +
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
                    cmd.CommandText = "UPDATE nogales SET nombre = @nombre, apellido = @apellido, telefono = @telefono, direccion = @direccion  WHERE id = @id";
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
                    cmd.CommandText = "DELETE FROM nogales WHERE id = @id";
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
