using MinesweeperASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperASP.NET.Services
{
    public class DataDAO
    {
        // Connection string may need to be updated
        // connectionString was copied from Micah's Activity 2 project
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Register;
                                   Integrated Security=True;
                                   Connect Timeout=30;
                                   Encrypt=False;
                                   TrustServerCertificate=False;
                                   ApplicationIntent=ReadWrite;
                                   MultiSubnetFailover=False";

        public bool save(gridDTO game)
        {
            int counter = 2;

             bool success = false;

            string sqlStatement = "INSERT INTO dbo.Games (GameString, Date, UserID) VALUES (@GameString, @Date, @UserID)";
            Console.WriteLine("@Date");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@GameString", SqlDbType.Text).Value = game.JSONString;
                command.Parameters.AddWithValue("@Date", SqlDbType.Text).Value = Convert.ToString(game.date);
                command.Parameters.AddWithValue("@UserID", SqlDbType.Int).Value = game.userID;
                try
                {
                    connection.Open();

                    var u = command.ExecuteNonQuery();

                    if (u > 0)
                    {
                        connection.Close();
                        success = true;

                    }

                    else
                    {
                        // print error to the console
                        Console.WriteLine("Not inserted correctly");
                        connection.Close();
                        success = false;
                    }
                } catch(Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
                return success;
            }
            
            
        }

        public List<gridDTO> retrieveData()
        {
            int counter = 2;
            List<gridDTO> list = new List<gridDTO>();
            bool success = false;

            string sqlStatement = "SELECT * FROM dbo.Games";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                try
                {
                    
                    connection.Open();
                    SqlDataReader sqlDataReader = command.ExecuteReader();



                    while (sqlDataReader.Read())
                    {
                        list.Add(new gridDTO
                        {
                            ID = (int)sqlDataReader[0],
                            JSONString = (string)sqlDataReader[1],
                            date = (DateTime)Convert.ToDateTime(sqlDataReader[2]),
                            userID = (int)sqlDataReader[3]
                        });

                    }
                    connection.Close();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    connection.Close();
                }
                return list;
            }
        }
        public gridDTO load()
        {
            int counter = 2;

            bool success = false;
            gridDTO dto = new gridDTO();
            string sqlStatement = "SELECT TOP 1 * FROM dbo.Games ORDER BY ID DESC";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        dto = new gridDTO((int)reader[0], (string)reader[1], (DateTime)Convert.ToDateTime(reader[2]), (int)reader[3]);

                    }
                    connection.Close();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    connection.Close();
                }
                return dto;
            }


        }

    }
}
