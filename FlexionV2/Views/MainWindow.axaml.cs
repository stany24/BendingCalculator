using Avalonia.Controls;
using LiveChartsCore.SkiaSharpView.Avalonia;

namespace FlexionV2.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        InitializeUi();
    }

    private void InitializeUi()
    {
        TextBlock lblForce = new() { Text = "Force:" };
        Grid.SetColumn(lblForce,0);
        Grid.SetRow(lblForce,0);
        GridForce.Children.Add(lblForce);
        NumericUpDown nudForce = new() { Value = 5 };
        Grid.SetColumn(nudForce,0);
        Grid.SetRow(nudForce,2);
        GridForce.Children.Add(nudForce);
        Button btnForce = new() { Content = "Modifier" };
        Grid.SetColumn(btnForce,0);
        Grid.SetRow(btnForce,4);
        GridForce.Children.Add(btnForce);
        
        TextBlock lblPiece = new() { Text = "Piece:" };
        Grid.SetColumn(lblPiece,0);
        Grid.SetRow(lblPiece,0);
        GridPiece.Children.Add(lblPiece);
        ListBox lbxPiece = new();
        Grid.SetColumn(lbxPiece,0);
        Grid.SetRow(lbxPiece,2);
        GridPiece.Children.Add(lbxPiece);
        Button btnPiece = new() { Content = "Modifier" };
        Grid.SetColumn(btnPiece,0);
        Grid.SetRow(btnPiece,4);
        GridPiece.Children.Add(btnPiece);
        
        TextBlock lblLayer = new() { Text = "Layer:" };
        Grid.SetColumn(lblLayer,0);
        Grid.SetRow(lblLayer,0);
        GridLayer.Children.Add(lblLayer);
        ListBox lbxLayer = new();
        Grid.SetColumn(lbxLayer,0);
        Grid.SetRow(lbxLayer,2);
        GridLayer.Children.Add(lbxLayer);
        Button btnLayer = new() { Content = "Modifier" };
        Grid.SetColumn(btnLayer,0);
        Grid.SetRow(btnLayer,4);
        GridLayer.Children.Add(btnLayer);
        
        TextBlock lblMaterial = new() { Text = "Material:" };
        Grid.SetColumn(lblMaterial,0);
        Grid.SetRow(lblMaterial,0);
        GridMaterial.Children.Add(lblMaterial);
        ListBox lbxMaterial = new();
        Grid.SetColumn(lbxMaterial,0);
        Grid.SetRow(lbxMaterial,2);
        GridMaterial.Children.Add(lbxMaterial);
        Button btnMaterial = new() { Content = "Modifier" };
        Grid.SetColumn(btnMaterial,0);
        Grid.SetRow(btnMaterial,4);
        GridMaterial.Children.Add(btnMaterial);
    }
}