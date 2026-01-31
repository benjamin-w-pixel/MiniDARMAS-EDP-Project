using System;
using System.Data.SqlClient;

namespace TestConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("Mini-DARMAS Connection Test");
            Console.WriteLine("==========================================");
            Console.WriteLine();

            // Test different connection strings
            string[] connectionStrings = new[]
            {
                @"Data Source=.\SQLEXPRESS;Initial Catalog=MiniDARMAS;Integrated Security=True;Connect Timeout=5;",
                @"Data Source=localhost\SQLEXPRESS;Initial Catalog=MiniDARMAS;Integrated Security=True;Connect Timeout=5;",
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MiniDARMAS;Integrated Security=True;Connect Timeout=5;",
                @"Data Source=localhost;Initial Catalog=MiniDARMAS;Integrated Security=True;Connect Timeout=5;"
            };

            string[] descriptions = new[]
            {
                "SQL Server Express (Default)",
                "SQL Server Express (localhost)",
                "LocalDB (MSSQLLocalDB)",
                "Local SQL Server"
            };

            bool foundWorking = false;

            for (int i = 0; i < connectionStrings.Length; i++)
            {
                Console.WriteLine($"Testing: {descriptions[i]}...");
                Console.WriteLine($"Connection String: {connectionStrings[i]}");
                
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionStrings[i]))
                    {
                        connection.Open();
                        Console.WriteLine("✓ Connection successful!");
                        
                        // Test if database exists
                        string checkDbQuery = "SELECT name FROM sys.databases WHERE name = 'MiniDARMAS'";
                        using (SqlCommand command = new SqlCommand(checkDbQuery, connection))
                        {
                            object result = command.ExecuteScalar();
                            if (result != null)
                            {
                                Console.WriteLine("✓ Database 'MiniDARMAS' exists!");
                                
                                // Test if tables exist
                                connection.ChangeDatabase("MiniDARMAS");
                                string checkTableQuery = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Users'";
                                using (SqlCommand tableCommand = new SqlCommand(checkTableQuery, connection))
                                {
                                    int tableCount = Convert.ToInt32(tableCommand.ExecuteScalar());
                                    if (tableCount > 0)
                                    {
                                        Console.WriteLine("✓ Tables are created!");
                                        Console.WriteLine();
                                        Console.WriteLine("==========================================");
                                        Console.WriteLine("SUCCESS! Your database is ready!");
                                        Console.WriteLine("==========================================");
                                        Console.WriteLine();
                                        Console.WriteLine($"Use this connection string in DatabaseHelper.cs:");
                                        Console.WriteLine();
                                        Console.WriteLine($"connectionString = @\"{connectionStrings[i]}\";");
                                        Console.WriteLine();
                                        foundWorking = true;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("⚠ Database exists but tables are missing.");
                                        Console.WriteLine("  Run the DatabaseSetup utility to create tables.");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("⚠ Database 'MiniDARMAS' does not exist.");
                                Console.WriteLine("  Run the DatabaseSetup utility to create it.");
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"✗ Connection failed: {ex.Message}");
                    if (ex.Number == 4060)
                    {
                        Console.WriteLine("  → Database 'MiniDARMAS' does not exist. Run DatabaseSetup first.");
                    }
                    else if (ex.Number == -1 || ex.Message.Contains("timeout"))
                    {
                        Console.WriteLine("  → Server not found or not running.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"✗ Error: {ex.Message}");
                }
                
                Console.WriteLine();
            }

            if (!foundWorking)
            {
                Console.WriteLine("==========================================");
                Console.WriteLine("No working connection found.");
                Console.WriteLine("==========================================");
                Console.WriteLine();
                Console.WriteLine("Possible solutions:");
                Console.WriteLine("1. Make sure SQL Server Express is running:");
                Console.WriteLine("   - Open Services (services.msc)");
                Console.WriteLine("   - Find 'SQL Server (SQLEXPRESS)'");
                Console.WriteLine("   - Start the service if it's stopped");
                Console.WriteLine();
                Console.WriteLine("2. Create the database first:");
                Console.WriteLine("   Run DatabaseSetup utility");
                Console.WriteLine();
                Console.WriteLine("3. If using a different instance name, update connection string");
                Console.WriteLine();
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}


