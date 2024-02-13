using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Flexion.Logic.Helper;
using Flexion.ViewModels;
using HyperText.Avalonia.Controls;

namespace Flexion.Views;

public partial class HelperWindow : Window
{
    public HelperWindow(IReadOnlyList<IHelperModule> modules,MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
        CreateUi(modules);
    }

    private void CreateUi(IReadOnlyList<IHelperModule> modules)
    {
        string rowDefinition = "";
        for (int i = 0; i < modules.Count; i++)
        {
            rowDefinition += "Auto,10,";
        }

        rowDefinition = rowDefinition.Remove(rowDefinition.Length - 4);
        MainGrid.RowDefinitions = RowDefinitions.Parse(rowDefinition);
        for (int i = 0; i < modules.Count; i++)
        {
            if (modules[i] is HelperImage helpImage)
            {
                Image image = new()
                {
                    Source = new Bitmap(AssetLoader.Open(new Uri(helpImage.Source)))
                };
                Grid.SetColumn(image,0);
                Grid.SetRow(image,2*i);
                MainGrid.Children.Add(image);
            }

            if (modules[i] is HelperText helpText)
            {
                TextBlock block = new()
                {
                    Text = helpText.Text
                };
                Grid.SetColumn(block,0);
                Grid.SetRow(block,2*i);
                MainGrid.Children.Add(block);
            }
            
            if (modules[i] is HelperButton helpLink)
            {
                Button link = new()
                {
                     Content = helpLink.DisplayText,
                     Command = (DataContext as MainViewModel).OpenLink,
                     CommandParameter = helpLink.Link
                };
                Grid.SetColumn(link,0);
                Grid.SetRow(link,2*i);
                MainGrid.Children.Add(link);
            }
        }
    }
}