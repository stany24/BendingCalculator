using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;

namespace FlexionV2.Views.Editors;

public abstract class Editor : Window
{
    internal readonly ListBox LbxItems = new();
    internal readonly Button BtnRemove= new();
    internal readonly Button BtnAdd= new();
    internal Task LoadTask = null!;
    internal Task SaveTask = null!;

    private protected Editor()
    {
        LbxItems.SelectionMode = SelectionMode.Multiple;
        BtnRemove.Click +=(_,_) => RemoveItems();
        BtnAdd.Content = "Ajouter";
        BtnRemove.Content = "Retirer";
    }

    internal DockPanel GetPanelJson<TClass>(ListBox listBox) where TClass : new()
    {
        DockPanel panel = new();
        Menu menu = new();
        DockPanel.SetDock(menu,Dock.Top);
        panel.Children.Add(menu);
        MenuItem jsonItem = new()
        {
            Header = "Json"
        };
        menu.Items.Add(jsonItem);
        MenuItem load = new(){ Header = "Load" };
        load.Click +=(_, _) => LoadTask =  LoadJson<TClass>(listBox);
        jsonItem.Items.Add(load);
        MenuItem save = new(){ Header = "Save" };
        save.Click +=(_, _) => SaveTask =  SaveJson<TClass>(listBox);
        jsonItem.Items.Add(save);
        return panel;
    }

    #region Json
    
    private static FilePickerFileType Json { get; } = new("Json file")
    {
        Patterns = new[] { "*.json" }
    };
    
    /// <summary>
    /// Generalized function used to load a list of T from a json file.
    /// </summary>
    /// <param name="listBox">The listbox you want to load into</param>
    /// <typeparam name="TClass">The class of T</typeparam>
    private async Task LoadJson<TClass>(ItemsControl listBox) where TClass : new()
    {
        Task<IReadOnlyList<IStorageFile>> task = StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Choose file to import from",
            AllowMultiple = false,
            FileTypeFilter = new[] { Json }
        });
        IReadOnlyList<IStorageFile> files = await task;
        if (!files.Any()) return;
        IStorageFile file = files[0];
        Stream stream = await file.OpenReadAsync();
        try
        {
            StreamReader reader = new(stream);
            string json = await reader.ReadToEndAsync();
            List<TClass> items = JsonSerializer.Deserialize<List<TClass>>(json) ?? new List<TClass>();
            listBox.Items.Clear();
            foreach (TClass item in items) listBox.Items.Add(item);
        }
        catch (Exception error)
        {
            Console.WriteLine(error);
        }
    }
    
    /// <summary>
    /// Generalized function used to save a list of T to a json file
    /// </summary>
    /// <param name="listbox">The listbox you want to save from</param>
    /// <typeparam name="TClass">The class ot T</typeparam>
    private async Task SaveJson<TClass>(ItemsControl listbox)
    {
        List<TClass> list = listbox.Items.Cast<TClass>().ToList();
        Task<IStorageFile?> task = StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
        {
            Title = "Choose where you want to save"
        });
        IStorageFile? file = await task;
        if (file == null) return;
        await using Stream stream = await file.OpenWriteAsync();
        try
        {
            string serialized = JsonSerializer.Serialize(list);
            await using StreamWriter writer = new(stream);
            await writer.WriteAsync(serialized);
        }
        catch (Exception error)
        {
            Console.WriteLine(error);
        }
    }

    #endregion
    
    #region UI update

    /// <summary>
    /// Generalized function used to update UI of the listbox
    /// </summary>
    /// <typeparam name="TItem">The class contained in the listbox</typeparam>
    private void UpdateListBox<TItem>()
    {
        List<TItem> items = LbxItems.Items.Cast<TItem>().ToList();
        List<TItem> selected = new();
        if (LbxItems.SelectedItems != null)
        {
            selected = LbxItems.SelectedItems.Cast<TItem>().ToList();
        }
        LbxItems.Items.Clear();
        foreach (TItem item in items) LbxItems.Items.Add(item);
        if (LbxItems.SelectedItems == null) return;
        foreach (TItem item in selected) LbxItems.SelectedItems.Add(item);
    }
    
    /// <summary>
    /// Generalized function used to modified one string property of selected items in the listbox from a text-box
    /// </summary>
    /// <param name="textBox">The input for the changed variable</param>
    /// <param name="propertyName">The property you want to change</param>
    /// <typeparam name="TItem">The class of item you want to change</typeparam>
    internal void TextChanged<TItem>(TextBox textBox, string propertyName)
    {
        if (LbxItems.SelectedItems == null) return;
        if (textBox.Text == null) return;
        foreach (TItem item in LbxItems.SelectedItems)
            item.GetType().GetProperty(propertyName)?.SetValue(item, textBox.Text);
        UpdateListBox<TItem>();
    }
    
    /// <summary>
    /// Generalized function used to modified one numerical property of selected items in the listbox from a numeric up down
    /// </summary>
    /// <param name="e">The event with the changed variable</param>
    /// <param name="propertyName">The property you want to change</param>
    /// <typeparam name="TItem">The class of item you want to change</typeparam>
    internal void NumericChanged<TItem>(NumericUpDownValueChangedEventArgs e, string propertyName)
    {
        if (LbxItems.SelectedItems == null) return;
        if (e.NewValue == null) return;
        foreach (TItem item in LbxItems.SelectedItems)
            item.GetType().GetProperty(propertyName)?.SetValue(item, (double)e.NewValue);
        UpdateListBox<TItem>();
    }
    
    /// <summary>
    /// Generalized function used to modified one boolean property of selected items in the listbox from a checkbox
    /// </summary>
    /// <param name="checkBox">The input for the changed variable</param>
    /// <param name="propertyName">The property you want to change</param>
    /// <typeparam name="TItem">The class of item you want to change</typeparam>
    internal void CheckBoxChanged<TItem>( CheckBox checkBox, string propertyName)
    {
        if (LbxItems.SelectedItems == null) return;
        if (checkBox.IsChecked == null) return;
        foreach (TItem item in LbxItems.SelectedItems)
            item.GetType().GetProperty(propertyName)?.SetValue(item, (bool)checkBox.IsChecked);
        UpdateListBox<TItem>();
    }
    
    /// <summary>
    /// Generalized function used to modified one enum property of selected items in the listbox with the value of a combobox
    /// </summary>
    /// <param name="listBox">The listbox you want the items to be changed</param>
    /// <param name="e">The event with the changed variable</param>
    /// <param name="propertyName">The property you want to change</param>
    /// <typeparam name="TItem">The class of item you want to change</typeparam>
    internal void ComboboxChanged<TItem,TType>(SelectionChangedEventArgs e, string propertyName)
    {
        if (LbxItems.SelectedItems == null) return;
        if (e.AddedItems[0] == null) return;
        foreach (TItem item in LbxItems.SelectedItems)
            item.GetType().GetProperty(propertyName)?.SetValue(item, (TType)e.AddedItems[0]!);
        UpdateListBox<TItem>();
    }
    
    /// <summary>
    /// Function used to remove all selected items from the listbox
    /// </summary>
    private void RemoveItems()
    {
        if (LbxItems.SelectedItems == null) return;
        int index = LbxItems.SelectedIndex;
        while (LbxItems.SelectedItems.Count > 0) LbxItems.Items.Remove(LbxItems.SelectedItems[0]);

        if (index <= 0) return;
        LbxItems.SelectedIndex = LbxItems.Items.Count > index ? index : LbxItems.Items.Count;
    }

    #endregion
}