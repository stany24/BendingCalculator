using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;

namespace FivemEconomy.Window.Editor;

public abstract class Editor : Avalonia.Controls.Window
{
    internal Task LoadTask = null!;
    internal Task SaveTask = null!;
    
    #region UI update

    /// <summary>
    /// Generalized function used to update UI of the listbox
    /// </summary>
    /// <param name="listbox">The listbox you want the UI to be updated</param>
    /// <typeparam name="TItem">The class contained in the listbox</typeparam>
    internal static void UpdateListBox<TItem>(ListBox listbox)
    {
        List<TItem> items = listbox.Items.Cast<TItem>().ToList();
        List<TItem> selected = new();
        if (listbox.SelectedItems != null)
        {
            selected = listbox.SelectedItems.Cast<TItem>().ToList();
        }
        listbox.Items.Clear();
        foreach (TItem item in items) listbox.Items.Add(item);
        if (listbox.SelectedItems == null) return;
        foreach (TItem item in selected) listbox.SelectedItems.Add(item);
    }
    
    /// <summary>
    /// Generalized function used to modified one string property of selected items in the listbox from a text-box
    /// </summary>
    /// <param name="listBox">The listbox you want the items to be changed</param>
    /// <param name="textBox">The input for the changed variable</param>
    /// <param name="propertyName">The property you want to change</param>
    /// <typeparam name="TItem">The class of item you want to change</typeparam>
    internal static void TextChanged<TItem>(ListBox listBox, TextBox textBox, string propertyName)
    {
        if (listBox.SelectedItems == null) return;
        if (textBox.Text == null) return;
        foreach (TItem item in listBox.SelectedItems)
            item.GetType().GetProperty(propertyName)?.SetValue(item, textBox.Text);
        UpdateListBox<TItem>(listBox);
    }
    
    /// <summary>
    /// Generalized function used to modified one numerical property of selected items in the listbox from a numeric up down
    /// </summary>
    /// <param name="listBox">The listbox you want the items to be changed</param>
    /// <param name="e">The event with the changed variable</param>
    /// <param name="propertyName">The property you want to change</param>
    /// <typeparam name="TItem">The class of item you want to change</typeparam>
    internal static void NumericChanged<TItem>(ListBox listBox, NumericUpDownValueChangedEventArgs e, string propertyName)
    {
        if (listBox.SelectedItems == null) return;
        if (e.NewValue == null) return;
        foreach (TItem item in listBox.SelectedItems)
            item.GetType().GetProperty(propertyName)?.SetValue(item, (int)e.NewValue);
        UpdateListBox<TItem>(listBox);
    }
    
    /// <summary>
    /// Generalized function used to modified one boolean property of selected items in the listbox from a checkbox
    /// </summary>
    /// <param name="listBox">The listbox you want the items to be changed</param>
    /// <param name="checkBox">The input for the changed variable</param>
    /// <param name="propertyName">The property you want to change</param>
    /// <typeparam name="TItem">The class of item you want to change</typeparam>
    internal static void CheckBoxChanged<TItem>(ListBox listBox, CheckBox checkBox, string propertyName)
    {
        if (listBox.SelectedItems == null) return;
        if (checkBox.IsChecked == null) return;
        foreach (TItem item in listBox.SelectedItems)
            item.GetType().GetProperty(propertyName)?.SetValue(item, (bool)checkBox.IsChecked);
        UpdateListBox<TItem>(listBox);
    }
    
    
    /// <summary>
    /// Function used to remove all selected items from the listbox
    /// </summary>
    /// <param name="listBox">The listbox you want to remove the selected items</param>
    internal static void RemoveItems(ListBox listBox)
    {
        if (listBox.SelectedItems == null) return;
        int index = listBox.SelectedIndex;
        while (listBox.SelectedItems.Count > 0) listBox.Items.Remove(listBox.SelectedItems[0]);

        if (index <= 0) return;
        listBox.SelectedIndex = listBox.Items.Count > index ? index : listBox.Items.Count;
    }

    #endregion
}