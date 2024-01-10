using System;
using System.Data.SQLite;
using System.IO;

namespace FlexionV2.Database.Actions;

public static class DataBaseInitializer
{
    public static SQLiteConnection InitializeDatabaseConnection()
    {
        SQLiteConnection connection;
        string databasePath = Path.Combine(Directory.GetCurrentDirectory(), "Database/Database.db");
        string connectionString = $"Data Source={databasePath};";
        try
        {
            Environment.SetEnvironmentVariable("SQLite_ConfigureDirectory", AppContext.BaseDirectory); // used to correct an issue with the last version of sqlite
            connection = new SQLiteConnection(connectionString);
            connection.Open();
            return connection;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error connecting to the database: {ex.Message}");
            return null;
        }
    } 
}