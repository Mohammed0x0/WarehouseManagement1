using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class UserMenu : Base
    {

        private bool IsTrueUser(int myid)
        {

            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();

                string updateQuery = " SELECT * FROM users WHERE id = @id";
                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@id", myid);
                    
                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    if (rowsAffected > 0 ) 
                    {

                        return true;
                    }
                    else
                    {

                        return false;
                    }
                }
            }


        }

        public static void ShowUserMenu(int myid)
        {
            if (myid != null)
            {
                while (true)
                {
                    Console.WriteLine("User Menu");
                    Console.WriteLine("1. Display Available Devices"); // Option to display available devices
                    Console.WriteLine("2. Display All Devices Under your Name");
                    Console.WriteLine("0. Exit");

                    Console.Write("Enter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            DisplayAvailableDevices();
                            break;
                        case 2:
                            DisplayAllDevicesForUser(myid);
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }

                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid username. User not found.");
            }
        }

        /// <summary>
        /// Retrieves the user ID based on the username.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>The user ID if found, or -1 if not found.</returns>
        
        /// <summary>
        /// Displays the available devices that are not assigned to any user.
        /// </summary>
        private static void DisplayAvailableDevices()
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                string query = "SELECT D.id , D.Name , D.SerialNumber FROM Devices D  INNER JOIN Status S ON D.ID != S.Device_id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    Console.WriteLine("Available Devices:");
                    while (reader.Read())
                    {
                        int deviceid = reader.GetInt32(0);
                        string deviceName = reader.GetString(1);
                        string deviceserial = reader.GetString(2);
                        Console.WriteLine($"Device name : {deviceid}, Device name : {deviceName}, Device Serial: {deviceserial}");
                    }

                    reader.Close();
                }
            }
        }

        /// <summary>
        /// Displays all devices assigned to a user based on the user ID.
        /// </summary>

        private static void DisplayAllDevicesForUser(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                string query = "SELECT D.Name , D.SerialNumber FROM Devices D INNER JOIN Status S ON D.ID = S.Device_id WHERE S.User_id = @userId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    Console.WriteLine("Devices assigned to user:");
                    while (reader.Read())
                    {
                        string deviceName = reader.GetString(0);
                        string serial = reader.GetString(1);
                        Console.WriteLine($"Device: {deviceName} , SerialNumber: {serial}");
                    }

                    reader.Close();
                }
            }
        }
    }
}
