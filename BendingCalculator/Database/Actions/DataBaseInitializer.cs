using System;
using System.Data.SQLite;
using System.IO;

namespace BendingCalculator.Database.Actions;

public static class DataBaseInitializer
{
    public static SQLiteConnection? InitializeDatabaseConnection()
    {
        string databasePath = Path.Combine(Directory.GetCurrentDirectory(), "Database/Database.db");
        string connectionString = $"Data Source={databasePath};";
        try
        {
            Environment.SetEnvironmentVariable("SQLite_ConfigureDirectory", AppContext.BaseDirectory); // used to correct an issue with the last version of sqlite
            SQLiteConnection connection = new(connectionString);
            connection.Open();
            return connection;
        }
        catch
        {
            return null;
        }
    } 
}