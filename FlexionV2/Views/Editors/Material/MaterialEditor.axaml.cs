using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Avalonia.Controls;
using Dapper;

namespace FlexionV2.Views.Editors.Material;

public partial class MaterialEditor : Editor
{
    public MaterialEditor(List<Logic.Material> materials)
    {
        InitializeComponent();
        InitializeUi();
        NudE.ValueChanged += (_, e) => NumericChanged<Logic.Material>(e,"E");
        TbxName.TextChanged += (_, _) => TextChanged<Logic.Material>(TbxName, "Nom");
        foreach (Logic.Material material in materials) { LbxItems.Items.Add(material); }
        Database();
    }

    private void InitializeUi()
    {
        Grid.SetColumn(LbxItems,0);
        Grid.SetRow(LbxItems,0);
        Grid.SetRowSpan(LbxItems,6);
        LbxItems.MinWidth = 200;
        Grid.Children.Add(LbxItems);
        Grid.SetColumn(BtnAdd,2);
        Grid.SetRow(BtnAdd,4);
        Grid.Children.Add(BtnAdd);
        Grid.SetColumn(BtnRemove,4);
        Grid.SetRow(BtnRemove,4);
        Grid.Children.Add(BtnRemove);
        BtnAdd.Click += (_, _) => LbxItems.Items.Add(new Logic.Material("new", 69e9));
    }

    private static void Database()
    {
        const string fileName = "/home/stan/Git/Flexion/FlexionV2/Database/Database.db";
        const string connectionString = $"Data Source={fileName};";
        try
        {
            // Create a new SQLiteConnection
            using SQLiteConnection connection = new(connectionString);
            // Open the connection explicitly
            connection.Open();
            connection.Execute("CREATE TABLE IF NOT EXISTS Material (Id INTEGER PRIMARY KEY, Name TEXT, E INT)");
            // Query all records from the Person table
            IEnumerable<Logic.Material> people = connection.Query<Logic.Material>("SELECT * FROM Material");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error connecting to the database: {ex.Message}");
        }
    }
}