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
    internal readonly Button BtnRemove= new();
    internal readonly Button BtnAdd= new();
    internal Task LoadTask = null!;
    internal Task SaveTask = null!;

    private protected Editor()
    {
        BtnAdd.Content = "Nouveau";
        BtnRemove.Content = "Supprimer";
    }

    #region Json
    
    private static FilePickerFileType Json { get; } = new("Json file")
    {
        Patterns = new[] { "*.json" }
    };
    
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
    protected virtual void UpdateListBox<TItem>(ListBox lbxItems)
    {
        List<TItem> items = lbxItems.Items.Cast<TItem>().ToList();
        List<TItem> selected = new();
        if (lbxItems.SelectedItems != null)
        {
            selected = lbxItems.SelectedItems.Cast<TItem>().ToList();
        }
        foreach (TItem item in items) lbxItems.Items.Add(item);
        if (lbxItems.SelectedItems == null) return;
        foreach (TItem item in selected) lbxItems.SelectedItems.Add(item);
    }
    
    /// <summary>
    /// Generalized function used to modified one string property of selected items in the listbox from a text-box
    /// </summary>
    /// <param name="textBox">The input for the changed variable</param>
    /// <param name="propertyName">The property you want to change</param>
    /// <typeparam name="TItem">The class of item you want to change</typeparam>
    internal void TextChanged<TItem>(ListBox lbxItems,TextBox textBox, string propertyName)
    {
        if (lbxItems.SelectedItems == null) return;
        if (textBox.Text == null) return;
        foreach (TItem item in lbxItems.SelectedItems)
            item.GetType().GetProperty(propertyName)?.SetValue(item, textBox.Text);
        UpdateListBox<TItem>(lbxItems);
    }

    /// <summary>
    /// Generalized function used to modified one enum property of selected items in the listbox with the value of a combobox
    /// </summary>
    /// <param name="e">The event with the changed variable</param>
    /// <param name="propertyName">The property you want to change</param>
    /// <typeparam name="TClass">The class of item you want to change</typeparam>
    /// <typeparam name="TProperty">The class of the property you want to change</typeparam>
    internal void ComboboxChanged<TClass,TProperty>(ListBox lbxItems,SelectionChangedEventArgs e, string propertyName)
    {
        if (lbxItems.SelectedItems == null) return;
        if (e.AddedItems[0] == null) return;
        foreach (TClass item in lbxItems.SelectedItems)
            item.GetType().GetProperty(propertyName)?.SetValue(item, (TProperty)e.AddedItems[0]!);
        UpdateListBox<TClass>(lbxItems);
    }
    
    /// <summary>
    /// Function used to remove all selected items from the listbox
    /// </summary>
    protected virtual void RemoveItems(ListBox lbxItems)
    {
        if (lbxItems.SelectedItems == null) return;
        int index = lbxItems.SelectedIndex;
        while (lbxItems.SelectedItems.Count > 0) lbxItems.Items.Remove(lbxItems.SelectedItems[0]);

        if (index <= 0) return;
        lbxItems.SelectedIndex = lbxItems.Items.Count > index ? index : lbxItems.Items.Count;
    }

    #endregion
}