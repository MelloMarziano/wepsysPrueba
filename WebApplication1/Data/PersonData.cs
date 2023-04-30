using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class PersonData
    {

        public static bool registerPerson(Persona persona)
        {
            using (SqlConnection connection = new SqlConnection(Conecction.connectionString))
            {
                SqlCommand cmd = new SqlCommand("stp_insert", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombres", persona.Nombres);
                cmd.Parameters.AddWithValue("@apellidos", persona.Apellidos);
                cmd.Parameters.AddWithValue("@matricula", persona.Matricula);
                cmd.Parameters.AddWithValue("@fechaNAcimiento", persona.FechaNacimiento);
                cmd.Parameters.AddWithValue("@ubicacionLatitud", persona.UbicacionLatitud);
                cmd.Parameters.AddWithValue("@ubicacionLongitud", persona.UbicacionLongitud);
                cmd.Parameters.AddWithValue("@ubicacionAltitud", persona.UbicacionAltitud);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<Persona> getAllPersons()
        {
            List<Persona> personList = new List<Persona>();
            using (SqlConnection connection = new SqlConnection(Conecction.connectionString))
            {
                SqlCommand cmd = new SqlCommand("stp_findAll", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            personList.Add(new Persona()
                            {
                                IdPersona = Convert.ToInt32(dr["IdPersona"]),
                                Nombres = dr["Nombres"].ToString(),
                                Apellidos = dr["apellidos"].ToString(),
                                Matricula = dr["Matricula"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"].ToString()),
                                UbicacionLatitud = Convert.ToDecimal(dr["UbicacionLatitud"]),
                                UbicacionLongitud = Convert.ToDecimal(dr["UbicacionLongitud"]),
                                UbicacionAltitud = Convert.ToDecimal(dr["UbicacionAltitud"]),

                            });
                        }
                    }
                    return personList;
                }
                catch (Exception ex)
                {
                    return personList;
                }
            }

        }

        public static Persona getByMatricula(string matricula)
        {
            Persona _persona = new Persona();
            using (SqlConnection connection = new SqlConnection(Conecction.connectionString))
            {
                SqlCommand cmd = new SqlCommand("stp_findByMatricula", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@matricula", matricula);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            _persona = new Persona()
                                {
                                IdPersona = Convert.ToInt32(dr["IdPersona"]),
                                Nombres = dr["Nombres"].ToString(),
                                Apellidos = dr["apellidos"].ToString(),
                                Matricula = dr["Matricula"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"].ToString()),
                                UbicacionLatitud = Convert.ToDecimal(dr["UbicacionLatitud"]),
                                UbicacionLongitud = Convert.ToDecimal(dr["UbicacionLongitud"]),
                                UbicacionAltitud = Convert.ToDecimal(dr["UbicacionAltitud"]),
                          };
                        }

                    }



                    return _persona;
                }
                catch (Exception ex)
                {
                    return _persona;
                }
            }
        }

    }
}