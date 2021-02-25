using MinesweeperASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperASP.NET.Services
{
    public class UsersDAO
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

        public bool AddAccountToDatabase(userModel user)
        {
            //int counter = 2;

            // bool success = false;

            // string sqlStatement = "INSERT INTO dbo.Users WHERE username = @username AND password = @password";

            string sqlInsertStatement = "INSERT INTO dbo.Users(firstname, lastname, gender, age, state, emailaddress, username, password) VALUES(@firstname, @lastname, @gender, @age, @state, @emailaddress, @username, @password)";
            Console.WriteLine("@firstName");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlInsertStatement, connection);
                                
                //command.Parameters.AddWithValue("@firstname", SqlDbType.Text).Value = user.FirstName;
                command.Parameters.Add("@firstname", SqlDbType.Text, 20).Value = user.FirstName;
                command.Parameters.Add("@lastname", SqlDbType.Text, 20).Value = user.LastName;
                command.Parameters.Add("@gender", SqlDbType.Text, 10).Value = user.Gender;
                command.Parameters.Add("@age", SqlDbType.Int, 40).Value = user.Age;
                command.Parameters.Add("@state", SqlDbType.Text, 10).Value = user.State;
                command.Parameters.Add("@emailaddress", SqlDbType.VarChar, 40).Value = user.EmailAddress;
                command.Parameters.Add("@username", SqlDbType.Text, 25).Value = user.UserName;
                command.Parameters.Add("@password", SqlDbType.VarChar, 25).Value = user.Password;


               var u = command.ExecuteNonQuery();
                
                    if (u > 0)
                    {
                        connection.Close();
                        return true;
                        
                    }
                 
                else
                {
                    // print error to the console
                    Console.WriteLine("Not inserted correctly");
                    connection.Close();
                    return false;    
                }
                 
            }

            
        }
   
        public bool FindUserByNameAndPassword(userModel user)
        {
            bool success = false;
            int found = 0;
            // Database name may need to be updated to a milestone DB that I created
            string sqlStatement = "SELECT * FROM dbo.Users WHERE CONVERT(VARCHAR,username) = '" + user.UserName + "' AND CONVERT(VARCHAR,password) = '" + user.Password + "'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        found++;   
                    }
                }
                catch (Exception e)
                {
                    // print error to the console
                    Console.WriteLine(e.Message);
                    success = false;
                };
            }

            if (found == 1)
            {
                success = true;
                return success;
            }
            else
            {
                success = false;
                return success;
            }
        }
    }
}
